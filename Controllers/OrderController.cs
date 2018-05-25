/**
 * @(#) OrderController.cs
 */

namespace projektas_2.MVC.Controller
{
    public class OrderController
    {
        CartController cartController;
        
        projektas_2.MVC.Model.Order order;
        
        projektas_2.MVC.Model.Cart_Item cartItem;
        
        projektas_2.MVC.Model.Payment payment;
        
        public void addInventoryToCart( Integer inventoryId, Integer userId )
        {
            
        }
        
        public void addItemToCart( Integer itemId, Integer userId )
        {
            
        }
        
        public void checkOutInventoryOrder( Integer userId )
        {
            
        }
        
        public projektas_2.MVC.Model.Order createInventoryOrder(  )
        {
            return null;
        }
        
        public void clearOrderCart(  )
        {
            
        }
        
        public projektas_2.MVC.Model.Inventory[] getInventoryOrderList(  )
        {
            return null;
        }
        
        public projektas_2.MVC.Model.Inventory getInventoryOrderDetails( Integer id )
        {
            return null;
        }
        
        public projektas_2.MVC.Model.Order getOrderDetails( Integer id )
        {
            return null;
        }
        
        public void payOrder(  )
        {
            
        }
        
        public projektas_2.MVC.Model.Order[] getOrders(  )
        {
            return null;
        }
        
        public projektas_2.MVC.Model.Order createOrder( Integer id )
        {
            return null;
        }
        
        public void updateOrderState( Integer id )
        {
            
        }
        
        public Boolean canUpdate(  )
        {
            return null;
        }
        
    }
    
}
