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
        public int UserId { get; set; }
        public int ItemId { get; set; }
        public User User { get; set; }
        public Item Item { get; set; }

        public void insert(  )
        {
            
        }
        
        public void select(  )
        {
            
        }
        
        public void delete(  )
        {
            
        }
        
        public void count1(  )
        {
            
        }
        
        public void find( int itemId, int userId )
        {
            
        }
        
        public void increment( int itemId, int userId )
        {
            
        }
        
        public void count(  )
        {
            
        }
        
        public void changeAmount(  )
        {
            
        }
        
    }
    
}
