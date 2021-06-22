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
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductRequestModel, DeleteProductResponseModel>
    {
        private IProductDBService _productDBService;
        public DeleteProductCommandHandler(IProductDBService productDBService)
        {
            _productDBService = productDBService;
        }

        public async Task<DeleteProductResponseModel> Handle(DeleteProductRequestModel request, CancellationToken cancellationToken)
        {
            var response = new DeleteProductResponseModel();
            var deleted = await _productDBService.DeleteProduct(request.Id);
            response.IsDeleted = deleted;

            return response;
        }
    }
}
