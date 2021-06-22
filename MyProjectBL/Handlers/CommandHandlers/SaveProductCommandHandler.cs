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
    public class SaveProductCommandHandler : IRequestHandler<SaveProductRequestModel, SaveProductResponseModel>
    {
        private IProductDBService _productDBService;
        public SaveProductCommandHandler(IProductDBService productDBService)
        {
            _productDBService = productDBService;
        }

        public async Task<SaveProductResponseModel> Handle(SaveProductRequestModel request, CancellationToken cancellationToken)
        {
            var response = new SaveProductResponseModel();
            var prd = new Product()
            {
                Description = request.Product.Description,
                Name = request.Product.Name,
                Price = request.Product.Price
            };
            var id  = await _productDBService.SaveProduct(prd);
            response.Id = id;

            return response;
        }
    }
}
