using System.ComponentModel.DataAnnotations.Schema;

namespace DishDeliveryWebSite.Models
{
    public partial class Dish
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string DishName { get; set; }
        public decimal Price { get; set; }

        [Newtonsoft.Json.JsonIgnore]
        [System.Text.Json.Serialization.JsonIgnore]
        public DishDescription DishDescription { get; set; }

        [Newtonsoft.Json.JsonIgnore]
        [System.Text.Json.Serialization.JsonIgnore]
        public ICollection<OrderDish> Orders { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        [System.Text.Json.Serialization.JsonIgnore]
        public ICollection<DishCategory> Categories { get; set; }
    }
}
