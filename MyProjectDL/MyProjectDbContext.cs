using System;
using MyProjectDL.Entities;
using Microsoft.EntityFrameworkCore;

namespace MyProjectDL
{
    public class MyProjectDbContext : DbContext
    {
        public MyProjectDbContext(DbContextOptions<MyProjectDbContext> options)
        : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
