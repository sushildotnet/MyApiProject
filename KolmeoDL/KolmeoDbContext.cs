using System;
using KolmeoDL.Entities;
using Microsoft.EntityFrameworkCore;

namespace KolmeoDL
{
    public class KolmeoDbContext : DbContext
    {
        public KolmeoDbContext(DbContextOptions<KolmeoDbContext> options)
        : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}
