using AutoMapper;
using AutoMapper.QueryableExtensions;
using DishDeliveryWebSite.Dtos;
using DishDeliveryWebSite.Models;
using DishDeliveryWebSite.Persistence;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using System.Security.Claims;

namespace DishDeliveryWebSite.Services
{
    public class AddOrderService
    {
        private readonly DishDeliveryContext _dishDeliveryContext;
        private readonly IMapper _mapper;

        public AddOrderService(DishDeliveryContext dishDeliveryContext, IMapper mapper)
        {
            _dishDeliveryContext = dishDeliveryContext;
            _mapper = mapper;
        }

        public async Task<ICollection<AddOrderDto>> AddOrderAsync(int userId, int[] dishsId)
        {
            var order = new Order
            {
                UserId = userId,
            };

            await _dishDeliveryContext.AddAsync(order);
            var lineCount = await _dishDeliveryContext.SaveChangesAsync();

            var orderDishs = new List<OrderDish>();
            foreach (var dishId in dishsId)
            {
                orderDishs.Add(new()
                {
                    DishId = dishId,
                    OrderId = order.Id
                });
            }

            await _dishDeliveryContext.AddRangeAsync(orderDishs);

            order.TotalPrice = await _dishDeliveryContext.Dishes
                .Where(d => dishsId.Contains(d.Id))
                .Select(d => d.Price)
                .SumAsync();

            order.DeliveryDate = DateTime.Now.AddDays(1);

            await _dishDeliveryContext.SaveChangesAsync();

            return await _dishDeliveryContext.Orders
                .Where(o => o.UserId == order.Id)
                .ProjectTo<AddOrderDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }
    }
}
