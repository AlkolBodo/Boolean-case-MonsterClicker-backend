using MonsterClickerAPI.Enumfolder;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace MonsterClickerAPI.Data_transfer.Request
{
    public class RegistrationRequest
    {
        [Required]
        public string? Email { get; set; }

        [Required]
        public string? Username { get; set; }

        [Required]
        public string? Password { get; set; }

        public Role Role { get; set; } = Role.User;
    }
}
