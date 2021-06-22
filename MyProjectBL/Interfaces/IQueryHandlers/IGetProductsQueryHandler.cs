using System;
using MyProjectBL.RequestModels;
using MyProjectBL.ResponseModels;

namespace MyProjectBL.Interfaces.IQueryHandlers
{
    public interface IGetProductsQueryHandler
    {
        GetProductsResponseModel GetProducts(GetProductsRequestModel requestModel);
    }
}
