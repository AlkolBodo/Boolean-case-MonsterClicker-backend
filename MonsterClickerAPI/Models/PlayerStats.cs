using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.DataProtection;

namespace MonsterClickerAPI.Models
{
    [Table("player_stats")]
    public class PlayerStats
    {
        [Key]
        [Column("id")] public int Id { get; set; }
        [Column("user_id")][ForeignKey("User")] public int UserId { get; set; }
        public User User { get; set; }
        [Column("inventory_id")][ForeignKey("PlayerInventory")] public int InventoryId { get; set; }
        public PlayerInventory PlayerInventory { get; set; }
        [Column("click_damage")] public float ClickDamage { get; set; }
        [Column("crit_chance")] public float CritChance { get; set; }
    }
}
