namespace DishDeliveryWebSite.Models
{
    public partial class Unit
    {
        public Unit()
        {
            FoodProducts = new HashSet<FoodProduct>();
        }

        public int Id { get; set; }
        public string? UnitName { get; set; }

        public virtual ICollection<FoodProduct> FoodProducts { get; set; }
    }
}
