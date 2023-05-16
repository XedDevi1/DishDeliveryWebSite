using DishDeliveryWebSite.Models;

namespace DishDeliveryWebSite.Dtos
{
    public class AddOrderDto
    {
        public decimal TotalPrice { get; set; }
        public DateTime DeliveryDate { get; set; }

        public UserDto User { get; set; }

        public ICollection<OrderDishDto> Dishes { get; set; }
    }
}
