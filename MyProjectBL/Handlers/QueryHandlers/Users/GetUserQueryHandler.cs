using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MyProjectBL.Models;
using MyProjectBL.RequestModels;
using MyProjectBL.ResponseModels;
using MyProjectDL;
using MyProjectDL.Interfaces;
using MediatR;

namespace MyProjectBL.Handlers.QueryHandlers
{
    public class GetUserQueryHandler : IRequestHandler<GetUserRequestModel, GetUserResponseModel>
    {
        private IUserDBService _userDBService;
        public GetUserQueryHandler(IUserDBService userDBService)
        {
            _userDBService = userDBService;
        }
        public async Task<GetUserResponseModel> Handle(GetUserRequestModel request, CancellationToken cancellationToken)
        {
            var response = new GetUserResponseModel();

            var usr = _userDBService.GetUserById(request.Id);
            if (usr == null) return null;

            response.User = new UserModel();
            response.User.FirstName = usr.FirstName;
            response.User.LastName = usr.LastName;
            response.User.Id = usr.Id;
            response.User.Username = usr.Username;
            response.User.IsAdmin = usr.IsAdmin;

            return response;
        }
    }

}
