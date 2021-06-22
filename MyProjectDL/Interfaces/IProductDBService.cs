using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyProjectDL.Entities;

namespace MyProjectDL.Interfaces
{
    public interface IProductDBService
    {
        IEnumerable<Product> GetAllProducts();
        Product GetProductById(int id);
        Task<int> SaveProduct(Product product);
        Task<bool> UpdateProduct(Product product);
        Task<bool> DeleteProduct(int id);
    }
}
