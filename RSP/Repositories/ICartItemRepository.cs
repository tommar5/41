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
        Task<ICollection<CartItemDto>> GetCartItems(string userId);
        Task<CartItemDto> GetSingleCartItem(int id);
        Task<int> Create(Cart_Item cart_item);
        Task<int> Edit(int id, int number);
        Task<int> Delete(int id);
    }
}
