namespace DishDeliveryWebSite.Models
{
    public class DishCategory
    {
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public int DishId { get; set; }
        public Dish Dish { get; set; }
    }
}
