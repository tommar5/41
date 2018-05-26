/**
 * @(#) ItemController.cs
 */

using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RSP.Dtos;
using RSP.Repositories;

namespace RSP.Controllers
{
    [Route("item")]
    public class ItemController : Controller
    {
        private readonly IItemRepository _repository;
        public ItemController(IItemRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        [Produces(typeof(ItemDto[]))]
        public async Task<IActionResult> ItemList()
        {
            ViewData["ItemList"] = await _repository.GetItems();
            return View("ItemList");
        }

        [HttpGet("{id}")]
        [Produces(typeof(ItemDto))]
        public async Task<IActionResult> ItemDetails([FromRoute] int id)
        {
            var viewModel = await _repository.GetSingleItem(id);

            return View("ItemDetails", viewModel);
        }
    }
}
