using AutoMapper;
using DishDeliveryWebSite.Dtos;
using DishDeliveryWebSite.Models;

namespace DishDeliveryWebSite.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Dish, GetAllDishesDto>();
            CreateMap<DishDescription, DishDescriptionDto>();
            CreateMap<Order, AddOrderDto>();
            CreateMap<User, UserDto>();
            CreateMap<OrderDish, OrderDishDto>();
            CreateMap<Dish, DishDto>();
        }
    }
}
