namespace DishDeliveryWebSite.Models
{
    public partial class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string DishList { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime DeliveryDate { get; set; }

        public User User { get; set; }

        [Newtonsoft.Json.JsonIgnore]
        [System.Text.Json.Serialization.JsonIgnore]
        public ICollection<OrderDish> Dishes { get; set; }
    }
}
