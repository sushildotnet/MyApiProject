using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyProjectBL.Models;
using MyProjectBL.RequestModels;
using MyProjectBL.ResponseModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;

namespace MyProjectApi.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<UserController> _logger;

        public UserController(IMediator mediator,ILogger<UserController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost("authenticate")]
        [AllowAnonymous]
        public async Task<AuthenticateUserResponseModel> Authenticate(AuthenticateUserRequestModel model)
        {

            var response = await _mediator.Send(model);

            return response;
        }

        [HttpGet]
        [Authorize(Roles = Role.Admin)]
        //[AllowAnonymous]
        public async Task<GetUsersResponseModel> GetAll()
        {

            var response = await _mediator.Send(new GetUsersRequestModel());

            return response;
        }
    }
}
