using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Collections.Generic;

namespace finalproject.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var db = new RestaurantContext(serviceProvider.GetRequiredService<DbContextOptions<RestaurantContext>>()))
            {
                if (db.Restaurant.Any())
                {
                    return;
                }

                db.Restaurant.AddRange(
                    new Restaurant
                    {
                        Name = "George's",
                        Address = "6516 Burling St",
                        PhoneNumber = "806-777-7420",
                        Cuisine = "American",
                        Reviews = new List<Review> {
                            new Review {ReviewNum = 4},
                            new Review {ReviewNum = 5}
                        }
                    }
                );

                db.SaveChanges(); 
            }
        }
    }
}