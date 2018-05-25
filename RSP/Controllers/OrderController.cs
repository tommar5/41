/**
 * @(#) OrderController.cs
 */

namespace RSP.Controllers
{
    public class OrderController
    {
        CartController cartController;
        
        Model.Order order;
        
        Model.Cart_Item cartItem;
        
        Model.Payment payment;
        
        public void addInventoryToCart( int inventoryId, int userId )
        {
            
        }
        
        public void addItemToCart( int itemId, int userId )
        {
            
        }
        
        public void checkOutInventoryOrder( int userId )
        {
            
        }
        
        public Model.Order createInventoryOrder(  )
        {
            return null;
        }
        
        public void clearOrderCart(  )
        {
            
        }
        
        public Model.Inventory[] getInventoryOrderList(  )
        {
            return null;
        }
        
        public Model.Inventory getInventoryOrderDetails( int id )
        {
            return null;
        }
        
        public Model.Order getOrderDetails( int id )
        {
            return null;
        }
        
        public void payOrder(  )
        {
            
        }
        
        public Model.Order[] getOrders(  )
        {
            return null;
        }
        
        public Model.Order createOrder( int id )
        {
            return null;
        }
        
        public void updateOrderState( int id )
        {
            
        }
        
        public bool canUpdate(  )
        {
            return null;
        }
        
    }
    
}
