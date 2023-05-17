using DishDeliveryWebSite.Models;

namespace DishDeliveryWebSite.Dtos
{
    public class GetAllDishesDto
    {
        public string DishName { get; set; }
        public decimal Price { get; set; }

        public DishDescription DishDescription { get; set; }
    }
}
