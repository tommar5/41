using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using RSP.Repositories;
using RSP.Database;
using RSP.Dtos;
using RSP.Models;

namespace RSP.Repositories
{
    public class CartItemRepository : ICartItemRepository
    {
        private readonly DbSet<Cart_Item> _cartCartItems;
        private readonly RspDbContext _context;
        private readonly IMapper _mapper;

        public CartItemRepository(RspDbContext context, IMapper mapper)
        {
            _cartCartItems = context.CartItems;
            _context = context;
            _mapper = mapper;
        }
        public async Task<ICollection<CartItemDto>> GetCartItems()
        {
            var cartItems = await _cartCartItems
                .ToArrayAsync();
            return _mapper.Map<ICollection<Cart_Item>, ICollection<CartItemDto>>(cartItems);
        }

        public async Task<CartItemDto> GetSingleCartItem(int id)
        {
            var cartItem = await _cartCartItems
                .SingleOrDefaultAsync(c => c.Id == id);
            return _mapper.Map<Cart_Item, CartItemDto>(cartItem);
        }
        public async Task<int> Create(Cart_Item cartItem)
        {
            await _cartCartItems.AddAsync(cartItem);
            await _context.SaveChangesAsync();
            return cartItem.Id;
        }
        public async Task<int> Edit(int id, int number)
        {
            var result = _cartCartItems.Find(id);
            if (result != null)
            {
                result.Number = number;
                await _context.SaveChangesAsync();
            }
            return id;
        }
        public async Task<int> Delete(int id)
        {
            Cart_Item cartItem = _cartCartItems.Single(c => c.Id == id);
            _cartCartItems.Remove(cartItem);
            await _context.SaveChangesAsync();
            return id;
        }
    }
}
