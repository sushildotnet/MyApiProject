using System;
using System.Linq;
using KolmeoDL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace KolmeoDL
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new KolmeoDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<KolmeoDbContext>>()))
            {
                if (context.Products.Any())
                {
                    return;   // Data was already seeded
                }

                context.Products.AddRange(
                    new Product
                    {
                        Id = 1,
                        Name = "iPhone 12",
                        Description = "Apple iPhone 12",
                        Price = 1200
                    },
                    new Product
                    {
                        Id = 2,
                        Name = "Samsung S 12",
                        Description = "Samsung S 12 2021",
                        Price = 900
                    });

                context.SaveChanges();
            }
        }
    }
}
