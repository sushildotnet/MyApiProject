using System;
using KolmeoBL.RequestModels;
using KolmeoBL.ResponseModels;

namespace KolmeoBL.Interfaces.IQueryHandlers
{
    public interface IGetProductsQueryHandler
    {
        GetProductsResponseModel GetProducts(GetProductsRequestModel requestModel);
    }
}
