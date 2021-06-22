using System;
using System.Threading;
using System.Threading.Tasks;
using MyProjectBL.RequestModels;
using MyProjectBL.ResponseModels;
using MyProjectDL;
using MyProjectDL.Entities;
using MediatR;
using MyProjectDL.Interfaces;

namespace MyProjectBL.Handlers.CommandHandlers
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductRequestModel, UpdateProductResponseModel>
    {
        private IProductDBService _productDBService;
        public UpdateProductCommandHandler(IProductDBService productDBService)
        {
            _productDBService = productDBService;
        }

        public async Task<UpdateProductResponseModel> Handle(UpdateProductRequestModel request, CancellationToken cancellationToken)
        {
            var response = new UpdateProductResponseModel();

            var updated = await _productDBService.UpdateProduct(new Product()
            {
                Id = request.Product.Id,
                Description = request.Product.Description,
                Name = request.Product.Name,
                Price = request.Product.Price
            });
            response.IsUpdated = updated;

            return response;
        }
    }
}
