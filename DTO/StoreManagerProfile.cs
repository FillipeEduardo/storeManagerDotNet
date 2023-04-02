using AutoMapper;
using storeManagerDotNet.Models;

namespace storeManagerDotNet.DTO;

public class StoreManagerProfile : Profile
{
    public StoreManagerProfile()
    {
        CreateMap<Product, ProductDTO>().ReverseMap();
    }
}
