/**
 * @(#) Cart_Item.cs
 */

using System.ComponentModel.DataAnnotations;

namespace RSP.Models
{
    public class Cart_Item
    {
        [Key]
        public int Id { get; set; }
        public string Type { get; set; }
        public int Number { get; set; }
        public User User { get; set; }
        public string UserId { get; set; }
        public Item Item { get; set; }
        public int ItemId { get; set; }
    }
}
