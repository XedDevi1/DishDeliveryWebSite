using Microsoft.AspNetCore.Identity;

namespace DishDeliveryWebSite.Models
{
    public partial class User : IdentityUser<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }


        [Newtonsoft.Json.JsonIgnore]
        [System.Text.Json.Serialization.JsonIgnore]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
