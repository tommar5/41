/**
 * @(#) ItemController.cs
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
    [Route("item")]
    public class ItemController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IItemRepository _repository;
        private readonly ICartItemRepository _cartRepository;
        public ItemController(UserManager<User> userManager, ICartItemRepository cartRepository, IItemRepository repository)
        {
            _userManager = userManager;
            _repository = repository;
            _cartRepository = cartRepository;
        }

       
        [HttpGet]
        [Authorize]
        [Produces(typeof(ItemDto[]))]
        public async Task<IActionResult> ItemList()
        {
            ViewData["ItemList"] = await _repository.GetItems();
            return View("ItemList");
        }

        [HttpGet("{id}")]
        [Authorize]
        [Produces(typeof(ItemDto))]
        public async Task<IActionResult> ItemDetails([FromRoute] int id)
        {
            var viewModel = await _repository.GetSingleItem(id);

            if (viewModel == null)
            {
                viewModel = await _repository.NotFound();
            }

            return View("ItemDetails", viewModel);
        }

        [Route("{id}/Create")]
        public async Task<RedirectToActionResult> Create([FromRoute] int id, [FromRoute] int? number)
        {
            var item = await _repository.GetSingleItem(id);
            if (item == null)
            {
                throw new Exception("Item was not found.");
            }
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var cartItemFromDb = await _cartRepository.GetCartItem(id, user.Id);
            if (cartItemFromDb != null)
            {
                var newNumber = cartItemFromDb.Number + (number ?? 1);
                await _cartRepository.EditCartItem(cartItemFromDb.Id, newNumber);
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
                await _cartRepository.Create(cartItem);
            }

            return RedirectToAction("ItemDetails");
        }
    }
}
