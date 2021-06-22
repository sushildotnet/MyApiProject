using System;
using System.Collections.Generic;
using MyProjectBL.Models;

namespace MyProjectBL.ResponseModels
{
    public class GetProductsResponseModel
    {
        public List<ProductModel> Products { get; set; } = new List<ProductModel>();
    }
}
