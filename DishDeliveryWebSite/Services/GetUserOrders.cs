using AutoMapper;
using AutoMapper.QueryableExtensions;
using DishDeliveryWebSite.Dtos;
using DishDeliveryWebSite.Models;
using DishDeliveryWebSite.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DishDeliveryWebSite.Services
{
    public class GetUserOrders
    {
        private readonly DishDeliveryContext _dishDeliveryContext;
        private readonly IMapper _mapper;

        public GetUserOrders(DishDeliveryContext dishDeliveryContext, IMapper mapper)
        {
            _dishDeliveryContext = dishDeliveryContext;
            _mapper = mapper;
        }

        public async Task<ICollection<AddOrderDto>> GetOrdersAsync(int userId)
        {
            return await _dishDeliveryContext.Orders
                .Where(o => o.UserId == userId)
                .ProjectTo<AddOrderDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }
    }
}
