using System;
using MyProjectBL.ResponseModels;
using MediatR;

namespace MyProjectBL.RequestModels
{
    public class GetUsersRequestModel : IRequest<GetUsersResponseModel>
    {
        public int Id { get; set; }
    }
}
