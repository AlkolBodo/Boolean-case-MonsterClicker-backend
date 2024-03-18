using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MonsterClickerAPI.Models
{
    [Table("user")]
    public class User
    {
        [Column("id")] [Key] public int Id { get; set; }
        [Column("player_id")] [ForeignKey("Player")] public int PlayerId { get; set; }
        public PlayerStats PlayerStats { get; set; }

        [Column("user_stat_id")] [ForeignKey("UserStats")] public int UserStatId { get; set; }
        public UserStats UserStats { get; set; }
        [Column("username")] public string Username { get; set; }   
        [Column("password")] public string Password { get; set; }

    }
}
