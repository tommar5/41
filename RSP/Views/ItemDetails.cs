/**
 * @(#) ItemDetails.cs
 */

namespace RSP.Views
{
    public class ItemDetails
    {
        Controllers.ItemController ItemController;
        
        public void showItemDetails( Models.Item item )
        {
            
        }
        
        public Models.Item updateItem( Models.Item item )
        {
            return null;
        }
        
        public int deleteItem( int id )
        {
            return 1;
        }
        
        public void showConfirmationModal(  )
        {
            
        }
        
        public bool confirm(  )
        {
            return true;
        }
        
        public Models.Item createNewItem( Models.Item item )
        {
            return null;
        }
        
        public int addToCart( int itemId, int userId )
        {
            return 1;
        }
        
    }
    
}
