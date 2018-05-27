using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RSP.Dtos;
using RSP.Models;

namespace RSP.Repositories
{
    public interface ICartItemRepository
    {
        Task<ICollection<CartItemDto>> GetCartItems();
        Task<ItemDto> GetSingleCartItem(int id);
        Task<int> Create(Cart_Item cart_item);
        Task<int> Edit(int id, String content);
        Task<int> Delete(int id);
    }
}
