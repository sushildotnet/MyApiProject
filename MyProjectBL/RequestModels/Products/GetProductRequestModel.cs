﻿using System;
using MyProjectBL.ResponseModels;
using MediatR;

namespace MyProjectBL.RequestModels
{
    public class GetProductRequestModel : IRequest<GetProductResponseModel>
    {
        public int Id { get; set; }
    }
}
