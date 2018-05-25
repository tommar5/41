/**
 * @(#) ItemController.cs
 */

namespace RSP.Controllers
{
    public class ItemController
    {
        Models.Inventory Inventory;
        
        Models.Item Item;
        
        public Models.Item[] getItemList(  )
        {
            return null;
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
