using System;
using MyProjectBL.ResponseModels;
using MediatR;

namespace MyProjectBL.RequestModels
{
    public class GetProductsRequestModel : IRequest<GetProductsResponseModel>
    {
        public int Id { get; set; }
    }
}
