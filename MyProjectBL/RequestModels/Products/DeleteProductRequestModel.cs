using System;
using MyProjectBL.Models;
using MyProjectBL.ResponseModels;
using MediatR;

namespace MyProjectBL.RequestModels
{
    public class DeleteProductRequestModel : IRequest<DeleteProductResponseModel>
    {
        public int Id { get; set; }
    }
}
