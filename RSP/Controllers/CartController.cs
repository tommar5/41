/**
 * @(#) CartController.cs
 */

using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RSP.Dtos;
using RSP.Repositories;

namespace RSP.Controllers
{
    [Route("card")]
    public class CartController : Controller
    {
        private readonly ICartItemRepository _repository;
        public CartController(ICartItemRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Produces(typeof(CartItemDto[]))]
        public async Task<IActionResult> getCartList()
        {
            ViewData["CartItemList"] = await _repository.GetCartItems();
            return View("CartItemList");
        }
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
