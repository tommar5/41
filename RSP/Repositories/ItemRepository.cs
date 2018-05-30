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
    public class ItemRepository : IItemRepository
    {
        private readonly DbSet<Item> _items;
        private readonly RspDbContext _context;
        private readonly IMapper _mapper;

        public ItemRepository(RspDbContext context, IMapper mapper)
        {
            _items = context.Items;
            _context = context;
            _mapper = mapper;
        }
        public async Task<ICollection<ItemDto>> GetItems()
        {
            var items = await _items
                .ToArrayAsync();
            //return items;
            return _mapper.Map<ICollection<Item>, ICollection<ItemDto>>(items);
        }

        public async Task<ItemDto> GetSingleItem(int id)
        {
            var item = await _items
                .SingleOrDefaultAsync(c => c.Id == id);
            return _mapper.Map<Item, ItemDto>(item);
        }
        public async Task<int> Create(Item item)
        {
            await _items.AddAsync(item);
            await _context.SaveChangesAsync();
            return item.Id;
        }
        public async Task<int> Edit(int id, string description)
        {
            var result = _items.Find(id);
            if (result != null)
            {
                result.Description = description;
                await _context.SaveChangesAsync();
            }
            return id;
        }
        public async Task<int> Delete(int id)
        {
            Item item = _items.Single(c => c.Id == id);
            _items.Remove(item);
            await _context.SaveChangesAsync();
            return id;
        }

        public async Task<ItemDto> NotFound()
        {
            var item = new ItemDto
            {
                Id = 999,
                Name = "default",
                Description = "default",
                Size = "null",
                Price = 0
            };
            return item;
        }
    }
}
