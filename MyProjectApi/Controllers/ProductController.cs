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
        public async Task<GetProductsResponseModel> GetAl()
        {
            var response = await _mediator.Send(new GetProductsRequestModel());
            return response;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ProductModel> GetById([FromRoute] int id)
        {
            var response = await _mediator.Send(new GetProductRequestModel() { Id=id});
            return response.Product;
        }

        [HttpPost]
        [Route("[action]")]
        [Authorize(Roles = Role.Admin+","+ Role.User)]
        public async Task<ProductModel> Save(ProductModel product)
        {
            var response = await _mediator.Send(new SaveProductRequestModel() { Product = product });
            if (response.Id > 0)
            {
                var savedProduct = await _mediator.Send(new GetProductRequestModel() { Id = response.Id });
                return savedProduct.Product;
            }

            return null;
        }

        [HttpPost]
        [Route("[action]")]
        [Authorize(Roles = Role.Admin+","+ Role.User)]
        public async Task<ProductModel> Update(ProductModel product)
        {
            var response = await _mediator.Send(new UpdateProductRequestModel() { Product = product });
            if (response.IsUpdated)
            {
                var savedProduct = await _mediator.Send(new GetProductRequestModel() { Id = product.Id });
                return savedProduct.Product;
            }

            return null;
        }

        [HttpPost]
        [Route("[action]")]
        [Authorize(Roles = Role.Admin)]
        public async Task<bool> Delete(int id)
        {
            var response = await _mediator.Send(new DeleteProductRequestModel() { Id = id });

            return response.IsDeleted;
        }
    }
}
