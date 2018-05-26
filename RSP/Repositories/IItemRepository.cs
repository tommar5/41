using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RSP.Dtos;
using RSP.Models;

namespace RSP.Repositories
{
    public interface IItemRepository
    {
        Task<ICollection<ItemDto>> GetItems();
        Task<ItemDto> GetSingleItem(int id);
        Task<int> Create(Item item);
        Task<int> Edit(int id, String content);
        Task<int> Delete(int id);
    }
}
