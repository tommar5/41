/**
 * @(#) Item.cs
 */

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RSP.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Size { get; set; }
        public float Price { get; set; }
        public IList<Cart_Item> CartItems { get; set; }
    }
}
