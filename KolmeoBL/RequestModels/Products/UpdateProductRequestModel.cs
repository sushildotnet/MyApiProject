using System;
using KolmeoBL.Models;
using KolmeoBL.ResponseModels;
using MediatR;

namespace KolmeoBL.RequestModels
{
    public class SaveProductRequestModel : IRequest<SaveProductResponseModel>
    {
        public ProductModel Product { get; set; }
    }
}
