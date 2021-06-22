using System;
using System.Collections.Generic;
using KolmeoBL.DTO;

namespace KolmeoBL.ResponseModels
{
    public class GetProductsResponseModel
    {
        public List<ProductDto> Products { get; set; }
    }
}
