﻿using System.Collections.Generic;
using System.Threading.Tasks;
using RSP.Dtos;
using RSP.Models;

namespace RSP.Repositories
{
    public interface ICartItemRepository
    {
        Task<ICollection<CartItemDto>> GetCartItems(string userId);
        Task<CartItemDto> GetSingleCartItem(int id);
        Task<CartItemDto> GetCartItem(int itemId, string userId);
        Task<float> GetSubtotal(string userId);
        Task<int> Create(Cart_Item cart_item);
        Task<int> EditCartItem(int id, int number);
        Task<int> Delete(int id);
    }
}
