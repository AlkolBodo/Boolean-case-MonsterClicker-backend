using Microsoft.AspNetCore.Identity;

namespace MonsterClickerAPI.Enumfolder
{
    public class AppUser : IdentityUser
    {
        public Role Role { get; set; }
    }
}
