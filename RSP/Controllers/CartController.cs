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
        private readonly IItemRepository _itemRepository;
        public CartController(
            UserManager<User> userManager,
            ICartItemRepository repository,
            IItemRepository itemRepository
        )
        {
            _userManager = userManager;
            _repository = repository;
            _itemRepository = itemRepository;
        }

        [HttpGet]
        [Authorize]
        [Produces(typeof(CartItemDto[]))]
        public async Task<IActionResult> CartList()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            ViewData["CartItemList"] = await _repository.GetCartItems(user.Id);
            ViewData["Subtotal"] = await _repository.GetSubtotal(user.Id);

            return View("CartItemList");
        }

        [Route("{id}/Delete")]
        public async Task<RedirectToActionResult> Delete([FromRoute] int id)
        {
            await _repository.Delete(id);
            return RedirectToAction("CartList");
        }

        [Route("{id}/Create")]
        public async Task<RedirectToActionResult> Create([FromRoute] int itemId, [FromRoute] int? number)
        {
            var item = await _itemRepository.GetSingleItem(itemId);
            if (item == null)
            {
                return RedirectToAction("CartList");
            }
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            var cartItem = new Cart_Item
            {
                ItemId = itemId,
                UserId = user.Id,
                Number = number ?? 1,
                Type = "Tipas"
            };

            await _repository.Create(cartItem);
            return RedirectToAction("CartList");
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
