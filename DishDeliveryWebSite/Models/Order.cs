namespace DishDeliveryWebSite.Models
{
    public partial class Order
    {
        public Order()
        {
            Dishes = new HashSet<Dish>();
        }

        public int Id { get; set; }
        public int? UserId { get; set; }
        public string? DishList { get; set; }
        public decimal? TotalPrice { get; set; }
        public DateTime? DeliveryDate { get; set; }

        public virtual User? User { get; set; }

        public virtual ICollection<Dish> Dishes { get; set; }
    }
}
