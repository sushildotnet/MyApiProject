using System;
using System.Threading;
using System.Threading.Tasks;
using KolmeoBL.RequestModels;
using KolmeoBL.ResponseModels;
using KolmeoDL;
using KolmeoDL.Entities;
using MediatR;

namespace KolmeoBL.Handlers.CommandHandlers
{
    public class SaveProductCommandHandler : IRequestHandler<SaveProductRequestModel, SaveProductResponseModel>
    {
        private KolmeoDbContext _context;

        public SaveProductCommandHandler(KolmeoDbContext context)
        {
            _context = context;
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
            _context.Products.Add(prd);
            await _context.SaveChangesAsync();
            response.Id = prd.Id;

            return response;
        }
    }
}
