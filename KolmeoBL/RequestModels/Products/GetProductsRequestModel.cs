using System;
using KolmeoBL.ResponseModels;
using MediatR;

namespace KolmeoBL.RequestModels
{
    public class GetProductsRequestModel : IRequest<GetProductsResponseModel>
    {
        public int Id { get; set; }
    }
}
