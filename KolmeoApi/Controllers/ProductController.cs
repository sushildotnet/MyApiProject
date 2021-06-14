using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KolmeoBL.DTO;
using KolmeoBL.RequestModels;
using KolmeoBL.ResponseModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace KolmeoApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<ProductController> _logger;

        public ProductController(IMediator mediator,ILogger<ProductController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet]
        public async Task<GetProductsResponseModel> GetAll()
        {
            var response = await _mediator.Send(new GetProductsRequestModel());
            return response;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ProductDto> GetAsync([FromRoute] int id)
        {
            var response = await _mediator.Send(new GetProductsRequestModel() { Id=id});
            return response.Products.SingleOrDefault();
        }
    }
}
