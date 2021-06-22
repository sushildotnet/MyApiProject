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
    public class GetProductsQueryHandler : IRequestHandler<GetProductsRequestModel, GetProductsResponseModel>
    {
        private IProductDBService _productDBService;
        public GetProductsQueryHandler(IProductDBService productDBService)
        {
            _productDBService = productDBService;
        }
        public async Task<GetProductsResponseModel> Handle(GetProductsRequestModel request, CancellationToken cancellationToken)
        {
            var response = new GetProductsResponseModel();

            response.Products = _productDBService.GetAllProducts().Select(p => new ProductModel()
            {
                Description = p.Description,
                Id = p.Id,
                Name = p.Name,
                Price = p.Price
            }).ToList();

            return response;
        }
    }

}
