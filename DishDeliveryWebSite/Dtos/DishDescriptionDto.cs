using DishDeliveryWebSite.Models;

namespace DishDeliveryWebSite.Dtos
{
    public class DishDescriptionDto
    {
        public int Calories { get; set; }
        public int Protein { get; set; }
        public int Fats { get; set; }
        public int Carbohydrates { get; set; }
    }
}
