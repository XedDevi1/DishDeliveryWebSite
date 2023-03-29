namespace DishDeliveryWebSite.Models
{
    public partial class FoodProduct
    {
        public FoodProduct()
        {
            Dishes = new HashSet<Dish>();
        }

        public string? ProductName { get; set; }
        public int? UnitId { get; set; }
        public int Id { get; set; }

        public virtual Unit? Unit { get; set; }

        public virtual ICollection<Dish> Dishes { get; set; }
    }
}
