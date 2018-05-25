/**
 * @(#) OrderController.cs
 */

using Microsoft.AspNetCore.Mvc;

namespace RSP.Controllers
{
    public class OrderController : Controller
    {
        CartController cartController;
        
        Models.Order order;
        
        Models.Cart_Item cartItem;
        
        Models.Payment payment;
        
        public void addInventoryToCart( int inventoryId, int userId )
        {
            
        }
        
        public void addItemToCart( int itemId, int userId )
        {
            
        }
        
        public void checkOutInventoryOrder( int userId )
        {
            
        }
        
        public Models.Order createInventoryOrder(  )
        {
            return null;
        }
        
        public void clearOrderCart(  )
        {
            
        }
        
        public Models.Inventory[] getInventoryOrderList(  )
        {
            return null;
        }
        
        public Models.Inventory getInventoryOrderDetails( int id )
        {
            return null;
        }
        
        public Models.Order getOrderDetails( int id )
        {
            return null;
        }
        
        public void payOrder(  )
        {
            
        }
        
        public Models.Order[] getOrders(  )
        {
            return null;
        }
        
        public Models.Order createOrder( int id )
        {
            return null;
        }
        
        public void updateOrderState( int id )
        {
            
        }
        
        public bool canUpdate(  )
        {
            return true;
        }
        
    }
    
}
