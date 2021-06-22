using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyProjectDL.Entities;
using MyProjectDL.Interfaces;

namespace MyProjectDL.Services
{
    public class ProductDBService : IProductDBService
    {
        private MyProjectDbContext _context;

        public ProductDBService(MyProjectDbContext context)
        {
            _context = context;
        }
        public async Task<bool> DeleteProduct(int id)
        {
            var prd = _context.Products.Find(id);
            _context.Products.Remove(prd);
            var rows = await _context.SaveChangesAsync();

            return rows > 0;
        }

        public IEnumerable<Product> GetAllProducts()
        {
                return _context.Products.ToList();
        }

        public Product GetProductById(int id)
        {
            return _context.Products.Find(id);
        }

        public async Task<int> SaveProduct(Product product)
        {
            var prd = new Product()
            {
                Description = product.Description,
                Name = product.Name,
                Price = product.Price
            };
            _context.Products.Add(prd);
            await _context.SaveChangesAsync();

            return prd.Id;
        }

        public async Task<bool> UpdateProduct(Product product)
        {
            var prd = _context.Products.Find(product.Id);

            prd.Description = product.Description;
            prd.Name = product.Name;
            prd.Price = product.Price;

            var rows = await _context.SaveChangesAsync();

            return rows > 0;
        }
    }
}
