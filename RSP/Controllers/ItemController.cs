/**
 * @(#) ItemController.cs
 */

using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RSP.Dtos;
using RSP.Repositories;

namespace RSP.Controllers
{
    public class ItemController : Controller
    {
        private readonly IItemRepository _repository;
        public ItemController(IItemRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        [Produces(typeof(ItemDto[]))]
        public async Task<IActionResult> ItemList(  )
        {
            ViewData["ItemList"] = await _repository.GetItems();
            return View("Items");
        }
        
        public Models.Item getItemDetails( int id )
        {
            return null;
        }
        
        public int createItem( Models.Item item )
        {
            return 1;
        }
        
        public int deleteItem( int id )
        {
            return 1;
        }
        
        public Models.Item updateItem( Models.Item item )
        {
            return null;
        }
        
        public bool checkIfValidItem( Models.Item item )
        {
            return true;
        }
        
        public Views.ItemDetails getCreatePage(  )
        {
            return null;
        }
        
    }
    
}
