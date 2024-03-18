using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MonsterClickerAPI.Models
{
    [Table("user_statistic")]
    public class UserStats
    {
        [Key]
        [Column("id")] public int Id { get; set; }
        [Column("User")] [ForeignKey("User")] public int UserId { get; set; }
        public User User { get; set; }
        [Column("clicks")] public int Clicks { get; set; }
        [Column("monsters_killed")] public int MonstersKilled { get; set; }
    }
}
