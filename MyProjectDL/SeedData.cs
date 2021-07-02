using System;
using System.Linq;
using MyProjectDL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MyProjectDL
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MyProjectDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<MyProjectDbContext>>()))
            {
                if (!context.Products.Any())
                {
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
                }
                //seed users
                if (!context.Users.Any())
                {
                    context.Users.AddRange(
                        new User
                        {
                            Id = 1,
                            FirstName = "test",
                            LastName = "test",
                            Username = "test",
                            Password = "test",
                            IsAdmin = false
                        },
                        new User
                        {
                            Id = 2,
                            FirstName = "test1",
                            LastName = "test1",
                            Username = "test1",
                            Password = "test1",
                            IsAdmin = false
                        },
                        new User
                        {
                            Id = 3,
                            FirstName = "admin",
                            LastName = "admin",
                            Username = "admin",
                            Password = "admin",
                            IsAdmin = true
                        });
                }
                context.SaveChanges();
            }
        }
    }
}
