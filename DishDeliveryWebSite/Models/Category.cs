namespace DishDeliveryWebSite.Models
{
    public partial class Category
    { 
        public int Id { get; set; }
        public int DishId { get; set; }
        public string Achivment { get; set; }
        public string CategoryName { get; set; }


        [Newtonsoft.Json.JsonIgnore]
        [System.Text.Json.Serialization.JsonIgnore]
        public ICollection<DishCategory> Dishes { get; set; }
    }
}
