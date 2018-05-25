/**
 * @(#) CartController.cs
 */

using Microsoft.AspNetCore.Mvc;

namespace RSP.Controllers
{
    public class CartController : Controller
    {
        Models.Cart_Item cartItem;
        
        public void addInventoryOrderToCart( int inventoryId, int userId )
        {
            
        }
        
        public Models.Cart_Item[] getInventoryOrderCartList( int userId )
        {
            return null;
        }
        
        public void deleteInventoryOrderFromCart( int inventoryId, int userId )
        {
            
        }
        
        public void addItemOrderToCart( int inventoryId, int userId )
        {
            
        }
        
        public Models.Cart_Item[] getItemOrderCartList( int userId )
        {
            return null;
        }
        
        public void deleteItemOrderFromCart( int inventoryId, int userId )
        {
            
        }
        
        public Models.Cart_Item getCartList(  )
        {
            return null;
        }
        
        public void getItemCount(  )
        {
            
        }
        
        public void removeFromCart( int id )
        {
            
        }
        
        public void purgeCart(  )
        {
            
        }
        
        public void updateItemCount( int id )
        {
            
        }
        
    }
    
}
