using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MyProjectBL.Models;
using MyProjectBL.RequestModels;
using MyProjectBL.ResponseModels;
using MyProjectDL;
using MyProjectDL.Interfaces;
using MediatR;

namespace MyProjectBL.Handlers.QueryHandlers
{
    public class GetProductQueryHandler : IRequestHandler<GetProductsRequestModel, GetProductsResponseModel>
    {
        private IProductDBService _productDBService;
        public GetProductQueryHandler(IProductDBService productDBService)
        {
            _productDBService = productDBService;
        }
        public async Task<GetProductsResponseModel> Handle(GetProductsRequestModel request, CancellationToken cancellationToken)
        {
            var products = new GetProductsResponseModel();
            if (request.Id > 0)
            {
                var product = _productDBService.GetProductById(request.Id);

                products.Products.Add(new ProductModel()
                {
                    Description = product.Description,
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price
                });
            }
            else
            {
                products.Products = _productDBService.GetAllProducts().Select(p => new ProductModel()
                {
                    Description = p.Description,
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price
                }).ToList();
            }
            return products;
        }
    }

}
