using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MonsterClickerAPI.Models
{
    [Table("monster_item_table")]
    public class MonsterItemTable
    {
        [Key][Column("id")] public int Id { get; set; }
        [Column("monster_id")][ForeignKey("Monster")] public int MonsterId { get; set; }
        public Monster Monster { get; set; }

        [Column("item_id")][ForeignKey("Item")] public int ItemId { get; set; }
        public Item Item { get; set; }

        [Column("drop_rate")] public float DropRate { get; set; }
        [Column("min_drop")] public int MinDrop { get; set; }
        [Column("max_drop")] public int MaxDrop { get; set; }

    }
}
