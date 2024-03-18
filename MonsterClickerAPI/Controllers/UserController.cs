


using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MonsterClickerAPI.Data;
using MonsterClickerAPI.Data_transfer.Request;
using MonsterClickerAPI.Data_transfer.Response;
using MonsterClickerAPI.Enumfolder;

namespace MonsterClickerAPI.Controllers
{
    [ApiController]
    [Route("/api[Controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly DataContext _dataContext;
        private readonly ServiceToken _serviceToken;

        public UserController(UserManager<AppUser> userManager, DataContext context,
           ServiceToken tokenService, ILogger<UserController> logger)
        {
            _userManager = userManager;
            _dataContext = context;
            _serviceToken = tokenService;
        }


        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(RegistrationRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var User = new AppUser { UserName = request.Username, Email = request.Email, Role = request.Role};

            var result = await _userManager.CreateAsync(
                User,
                request.Password!
            );

            if (result.Succeeded)
            {
                request.Password = "";
                var accessToken = _serviceToken.CreateToken(User);

                // Include the access token in the response
                var response = new
                {
                    Email = request.Email,
                    Role = request.Role,
                    AccessToken = accessToken,
                    ///Use this for frontend
                    Id = User.Id
                };

                return CreatedAtAction(nameof(Register), response);
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(error.Code, error.Description);
            }

            return BadRequest(ModelState);
        }


        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<AuthResponse>> Authenticate([FromBody] AuthRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var managedUser = await _userManager.FindByEmailAsync(request.Email!);

            if (managedUser == null)
            {
                return BadRequest("Bad credentials");
            }

            var isPasswordValid = await _userManager.CheckPasswordAsync(managedUser, request.Password!);

            if (!isPasswordValid)
            {
                return BadRequest("Bad credentials");
            }

            var userInDb = _dataContext.Users.FirstOrDefault(u => u.Email == request.Email);

            if (userInDb is null)
            {
                return Unauthorized();
            }

            var accessToken = _serviceToken.CreateToken(userInDb);
            await _dataContext.SaveChangesAsync();

            return Ok(new AuthResponse
            {
                Username = userInDb.UserName,
                Email = userInDb.Email,
                Token = accessToken,
            });
        }
    }
}
