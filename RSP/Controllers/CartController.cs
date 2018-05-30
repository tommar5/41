/**
 * @(#) CartController.cs
 */

using System;
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
        private readonly ICartItemRepository _cartItemRepository;
        private readonly IItemRepository _itemRepository;
        public Func<string> GetUserName; //For testing

        public CartController(
            UserManager<User> userManager,
            ICartItemRepository cartItemRepository,
            IItemRepository itemRepository
        )
        {
            _userManager = userManager;
            _cartItemRepository = cartItemRepository;
            _itemRepository = itemRepository;

            GetUserName = () => User.Identity.Name;
        }

        [HttpGet]
        [Authorize]
        [Produces(typeof(CartItemDto[]))]
        public async Task<IActionResult> CartList()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            ViewData["CartItemList"] = await _cartItemRepository.GetCartItems(user.Id);
            ViewData["Subtotal"] = await _cartItemRepository.GetSubtotal(user.Id);

            return View("CartItemList");
        }

        [Route("{id}/Delete")]
        [Authorize]
        public async Task<RedirectToActionResult> Delete([FromRoute] int id)
        {
            await _cartItemRepository.Delete(id);
            return RedirectToAction("CartList");
        }

        [Route("{id}/Create")]
        public async Task<RedirectToActionResult> AddItemToCart([FromRoute] int id, [FromRoute] int? number)
        {
            var item = await _itemRepository.GetSingleItem(id);
            if (item == null)
            {
                throw new Exception("Item was not found.");
            }
            var user = await _userManager.FindByNameAsync(GetUserName());
            var cartItemFromDb = await _cartItemRepository.GetCartItem(id, user.Id);
            if (cartItemFromDb != null)
            {
                var newNumber = cartItemFromDb.Number + (number ?? 1);
                await _cartItemRepository.EditCartItem(cartItemFromDb.Id, newNumber);
            }
            else
            {
                var cartItem = new Cart_Item
                {
                    ItemId = id,
                    UserId = user.Id,
                    Number = number ?? 1,
                    Type = "Tipas"
                };
                await _cartItemRepository.Create(cartItem);
            }

            return RedirectToAction("ItemDetails", "Item");
        }
    }
}
