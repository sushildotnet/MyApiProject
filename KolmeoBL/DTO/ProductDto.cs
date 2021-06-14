using System;
namespace KolmeoBL.DTO
{
    public class ProductDto
    {
        public ProductDto()
        {
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
