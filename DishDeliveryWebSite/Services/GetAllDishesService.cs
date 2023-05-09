using DishDeliveryWebSite.Models;
using DishDeliveryWebSite.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DishDeliveryWebSite.Services
{
    public class GetAllDishesService
    {
        private readonly DishDeliveryContext _dishDeliveryContext;

        public GetAllDishesService(DishDeliveryContext dishDeliveryContext)
        {
            _dishDeliveryContext = dishDeliveryContext;
        }
        public async Task<ICollection<Dish>> GetAllDishes()
        {
            return _dishDeliveryContext.Dishes.ToList();
        }
    }
}
