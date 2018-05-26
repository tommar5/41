/**
 * @(#) Item.cs
 */

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

        //public Inventory Inventory { get; set; }
        //public Supplier Supplier { get; set; }
        //public Cart_Item CartItems { get; set; }

        public void select(  )
        {
            
        }
        
        public void update(  )
        {
            
        }
        
        public void insert(  )
        {
            
        }
        
        public void delete(  )
        {
            
        }
        
    }
    
}
