using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KolmeoBL.DTO;
using KolmeoBL.RequestModels;
using KolmeoBL.ResponseModels;
using KolmeoDL;
using MediatR;

namespace KolmeoBL.Handlers.QueryHandlers
{
    public class GetProductQueryHandler : IRequestHandler<GetProductsRequestModel, GetProductsResponseModel>
    {
        private KolmeoDbContext _context;

        public GetProductQueryHandler(KolmeoDbContext context)
        {
            _context = context;
        }
        public async Task<GetProductsResponseModel> Handle(GetProductsRequestModel request, CancellationToken cancellationToken)
        {
            var products = new GetProductsResponseModel();
            if (request.Id > 0)
            {
                products.Products = _context.Products.Where(p=>p.Id==request.Id)
                    .Select(p => new ProductDto()
                {
                    Description = p.Description,
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price
                }).ToList();
            }
            else
            {
                products.Products = _context.Products.ToList().Select(p => new ProductDto()
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
