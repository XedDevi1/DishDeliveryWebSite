namespace DishDeliveryWebSite.Models
{
    public partial class Dish
    {
        public Dish()
        {
            FoodProducts = new HashSet<FoodProduct>();
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string? DishName { get; set; }
        public decimal? Price { get; set; }
        public int? CategoryId { get; set; }

        public virtual Category? Category { get; set; }
        public virtual DishDescription IdNavigation { get; set; } = null!;

        public virtual ICollection<FoodProduct> FoodProducts { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
