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
    public class GetProductQueryHandler : IRequestHandler<GetProductRequestModel, GetProductResponseModel>
    {
        private IProductDBService _productDBService;
        public GetProductQueryHandler(IProductDBService productDBService)
        {
            _productDBService = productDBService;
        }
        public async Task<GetProductResponseModel> Handle(GetProductRequestModel request, CancellationToken cancellationToken)
        {
            var response = new GetProductResponseModel();
            if (request.Id > 0)
            {
                var product = _productDBService.GetProductById(request.Id);

                response.Product = new ProductModel()
                {
                    Description = product.Description,
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price
                };
            }
            return response;
        }
    }

}
