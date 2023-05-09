using DishDeliveryWebSite.Models;
using DishDeliveryWebSite.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace DishDeliveryWebSite.Helpers
{
    public static class SeedingData
    {
        public static void Seed(this IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<DishDeliveryContext>();

                context.Database.Migrate();

                if (!context.Categories.Any())
                {
                    var categories = new List<Category>()
                    {
                        new Category
                        {
                            CategoryName = "Office",
                            Achivment = "800 ккал",
                            DishId = 1
                        },
                        new Category
                        {
                            CategoryName = "Light",
                            Achivment = "1100 ккал"
                        },
                        new Category
                        {
                            CategoryName = "Standart",
                            Achivment = "1300 ккал"
                        },
                        new Category
                        {
                            CategoryName = "Medium",
                            Achivment = "1600 ккал"
                        },
                        new Category
                        {
                            CategoryName = "Balance",
                            Achivment = "2000 ккал"
                        },
                        new Category
                        {
                            CategoryName = "Strong",
                            Achivment = "2500 ккал"
                        },
                        new Category
                        {
                            CategoryName = "Ultra",
                            Achivment = "3200 ккал"
                        }
                    };

                    //_context.Categories.AddRange(categories);
                    //_context.SaveChanges();
                }

                if (!context.DishDescriptions.Any())
                {
                    var dishDescriptions = new List<DishDescription>()
                    {
                        new DishDescription
                        {
                            Calories = 270,
                            Protein = 20,
                            Fats = 19,
                            Carbohydrates = 5,
                            DishId = 1
                        },
                        new DishDescription
                        {
                            Calories = 270,
                            Protein = 19,
                            Fats = 16,
                            Carbohydrates = 4,
                            DishId = 2
                        },
                        new DishDescription
                        {
                            Calories = 183,
                            Protein = 16,
                            Fats = 13,
                            Carbohydrates = 3,
                            DishId = 3
                        },
                        new DishDescription
                        {
                            Calories = 398,
                            Protein = 33,
                            Fats = 13,
                            Carbohydrates = 33,
                            DishId = 4
                        },
                        new DishDescription
                        {
                            Calories = 192,
                            Protein = 19,
                            Fats = 11,
                            Carbohydrates = 5,
                            DishId = 5
                        },
                        new DishDescription
                        {
                            Calories = 340,
                            Protein = 37,
                            Fats = 8,
                            Carbohydrates = 32,
                            DishId = 6
                        },
                        new DishDescription
                        {
                            Calories = 233,
                            Protein = 4,
                            Fats = 3,
                            Carbohydrates = 51,
                            DishId = 7
                        },
                        new DishDescription
                        {
                            Calories = 375,
                            Protein = 39,
                            Fats = 6,
                            Carbohydrates = 29,
                            DishId = 8
                        },
                        new DishDescription
                        {
                            Calories = 367,
                            Protein = 47,
                            Fats = 4,
                            Carbohydrates = 29,
                            DishId = 9
                        },
                        new DishDescription
                        {
                            Calories = 170,
                            Protein = 15,
                            Fats = 7,
                            Carbohydrates = 9,
                            DishId = 10
                        },
                        new DishDescription
                        {
                            Calories = 245,
                            Protein = 15,
                            Fats = 17,
                            Carbohydrates = 7,
                            DishId = 11
                        }
                    };

                    //_context.DishDescriptions.AddRange(dishDescriptions);
                    //_context.SaveChanges();
                }

                if (!context.Dishes.Any())
                {
                    var dishes = new List<Dish>()
                    {
                        new Dish
                        {
                            DishName = "Глазунья с овощами",
                            Price = 23,
                        },
                        new Dish
                        {
                            DishName = "Омлет овощной",
                            Price = 25,
                        },
                        new Dish
                        {
                            DishName = "Греческий салат",
                            Price = 16,
                        },
                        new Dish
                        {
                            DishName = "Котлеты с курицей и капустой",
                            Price = 13.4m,
                        },
                        new Dish
                        {
                            DishName = "Салат грибной",
                            Price = 25,
                        },
                        new Dish
                        {
                            DishName = "Запеченное куриное филес чечевицей",
                            Price = 43,
                        },
                        new Dish
                        {
                            DishName = "Рисовая каша с мандаринами",
                            Price = 22,
                        },
                        new Dish
                        {
                            DishName = "Цыпленок с фасолью",
                            Price = 38,
                        },
                        new Dish
                        {
                            DishName = "Рулет из курицы с овощами и чечевицей",
                            Price = 35,
                        },
                        new Dish
                        {
                            DishName = "Овощной салат с яблочной заправкой",
                            Price = 25,
                        },
                        new Dish
                        {
                            DishName = "Пашот с овощами",
                            Price = 13,
                        }
                    };

                    //_context.Dishes.AddRange(dishes);
                    //_context.SaveChanges();
                }

                if (!context.DishCategories.Any())
                {
                    var dishCategories = new List<DishCategory>()
                    {
                        new DishCategory
                        {
                            CategoryId = 1,
                            DishId = 1
                        },
                        new DishCategory
                        {
                            CategoryId = 1,
                            DishId = 2
                        }
                    };
                }
            }
        }
    }
}
