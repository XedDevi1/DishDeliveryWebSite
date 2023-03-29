using Microsoft.EntityFrameworkCore;

namespace DishDeliveryWebSite.Helpers
{
    public class DbContextHelper
    {
        public static async Task ApplyMigrations(DbContext context)
        {
            await context.Database.MigrateAsync();
        }
    }
}
