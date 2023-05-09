using System.ComponentModel.DataAnnotations.Schema;

namespace DishDeliveryWebSite.Models
{
    public partial class DishDescription
    {
        public int Id { get; set; }
        public int Calories { get; set; }
        public int Protein { get; set; }
        public int Fats { get; set; }
        public int Carbohydrates { get; set; }
        public int DishId { get; set; }

        [Newtonsoft.Json.JsonIgnore]
        [System.Text.Json.Serialization.JsonIgnore]
        public Dish Dish { get; set; }
    }
}
