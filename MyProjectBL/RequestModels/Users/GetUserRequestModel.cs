using System;
using MyProjectBL.ResponseModels;
using MediatR;

namespace MyProjectBL.RequestModels
{
    public class GetUserRequestModel : IRequest<GetUserResponseModel>
    {
        public int Id { get; set; }
    }
}
