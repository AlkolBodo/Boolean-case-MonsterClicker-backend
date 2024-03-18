using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MonsterClickerAPI.Models
{
    [Table("item")]
    public class Item
    {
        [Key][Column("id")] public int Id { get; set; }
        [Column("item_name")] public string ItemName { get; set; }
        [Column("item_sprite_url")] public string ItemSpriteUrl { get; set; }
    }
}
