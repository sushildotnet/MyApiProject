using System;
using MyProjectBL.Models;
using MyProjectBL.ResponseModels;
using MediatR;

namespace MyProjectBL.RequestModels
{
    public class SaveProductRequestModel : IRequest<SaveProductResponseModel>
    {
        public ProductModel Product { get; set; }
    }
}
