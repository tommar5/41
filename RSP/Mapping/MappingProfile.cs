using AutoMapper;
using RSP.Dtos;
using RSP.Models;

namespace RSP.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Item, ItemDto>();
            CreateMap<Cart_Item, CartItemDto>();
        }
    }
}
