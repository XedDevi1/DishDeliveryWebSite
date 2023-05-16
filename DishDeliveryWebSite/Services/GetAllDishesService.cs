using AutoMapper;
using AutoMapper.QueryableExtensions;
using DishDeliveryWebSite.Dtos;
using DishDeliveryWebSite.Models;
using DishDeliveryWebSite.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DishDeliveryWebSite.Services
{
    public class GetAllDishesService
    {
        private readonly DishDeliveryContext _dishDeliveryContext;
        private readonly IMapper _mapper;

        public GetAllDishesService(DishDeliveryContext dishDeliveryContext, IMapper mapper)
        {
            _dishDeliveryContext = dishDeliveryContext;
            _mapper = mapper;
        }
        public async Task<ICollection<GetAllDishesDto>> GetAllDishes()
        {
            return await _dishDeliveryContext.Dishes
                    .ProjectTo<GetAllDishesDto>(_mapper.ConfigurationProvider)
                    .ToListAsync();
        }
    }
}
