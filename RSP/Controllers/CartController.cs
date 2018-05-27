/**
 * @(#) CartController.cs
 */

using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RSP.Dtos;
using RSP.Models;
using RSP.Repositories;

namespace RSP.Controllers
{
    [Route("cart")]
    public class CartController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly ICartItemRepository _repository;
        public CartController(UserManager<User> userManager, ICartItemRepository repository)
        {
            _userManager = userManager;
            _repository = repository;
        }

        [HttpGet]
        [Authorize]
        [Produces(typeof(CartItemDto[]))]
        public async Task<IActionResult> CartList()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            ViewData["CartItemList"] = await _repository.GetCartItems(user.Id);
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
