namespace DishDeliveryWebSite.Models
{
    public partial class Category
    {
        public Category()
        {
            Dishes = new HashSet<Dish>();
        }

        public int Id { get; set; }
        public string? Achivment { get; set; }
        public string? CategoryName { get; set; }

        public virtual ICollection<Dish> Dishes { get; set; }
    }
}
