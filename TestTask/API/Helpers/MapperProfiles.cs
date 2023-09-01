using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Entities.Order;
using Core.Entities.Product;

namespace API.Helpers
{
    public class MapperProfiles : Profile
    {
        public MapperProfiles()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(p => p.Category, o => o.MapFrom(c => c.Category.Name));

            CreateMap<CustomerDto, Customer>();
            CreateMap<Customer, CustomerDto>();

            CreateMap<Order, OrderDto>()
                .ForMember(o => o.CustomerName, o => o.MapFrom(c => c.Customer.Name))
                .ForMember(o => o.CustomerAddress, o => o.MapFrom(c => c.Customer.Address));

            CreateMap<ProductItem, ProductItemDto>()
                .ForMember(o => o.ProductName, o => o.MapFrom(c => c.Product.Name))
                .ForMember(o => o.CreatedDate, o => o.MapFrom(c => c.Product.CreatedDate))
                .ForMember(o => o.Category, o => o.MapFrom(c => c.Product.Category.Name))
                .ForMember(o => o.Size, o => o.MapFrom(c => c.Size.Name))
                .ForMember(o => o.Description, o => o.MapFrom(c => c.Product.Description));

            CreateMap<OrderItem, OrderItemDto>()
                .ForMember(d => d.ProductId, o => o.MapFrom(s => s.ItemOrdered.ProductItemId))
                .ForMember(d => d.Size, o => o.MapFrom(s => s.ItemOrdered.Size))
                .ForMember(d => d.Category, o => o.MapFrom(s => s.ItemOrdered.Category))
                .ForMember(d => d.ProductName, o => o.MapFrom(s => s.ItemOrdered.ProductName));

            CreateMap<OrderItemDto, BasketItem>();
        }
    }
}