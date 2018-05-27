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
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using RSP.Controllers;

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

        public async Task<ICollection<CartItemDto>> GetCartItems(string userId)
        {
            var cartItems = await _cartCartItems
                .Include(c => c.Item)
                .Include(c => c.User)
                .Where(c => c.UserId == userId)
                .ToArrayAsync();
            return _mapper.Map<ICollection<Cart_Item>, ICollection<CartItemDto>>(cartItems);
        }

        public async Task<CartItemDto> GetSingleCartItem(int id)
        {
            var cartItem = await _cartCartItems
                .SingleOrDefaultAsync(c => c.Id == id);
            return _mapper.Map<Cart_Item, CartItemDto>(cartItem);
        }

        public async Task<CartItemDto> FindCartItem(int itemId, string userId)
        {
            var cartItem = await _cartCartItems
                .Include(c => c.Item)
                .Include(c => c.User)
                .Where(c => c.Item.Id == itemId)
                .Where(c => c.User.Id == userId)
                .SingleOrDefaultAsync();
            return _mapper.Map<Cart_Item, CartItemDto>(cartItem);
        }

        public async Task<float> GetSubtotal(string userId)
        {
            var sum = await _cartCartItems
                .Include(c => c.Item)
                .Include(c => c.User)
                .Where(c => c.User.Id == userId)
                .Select(c => c.Number * c.Item.Price)
                .SumAsync();

            return sum;
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
