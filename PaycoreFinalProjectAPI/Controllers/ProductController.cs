using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaycoreFinalProject.Base.Response;
using PaycoreFinalProject.Dto.DTOs;
using PaycoreFinalProject.Service.Abstract;
using System.Collections.Generic;
using PaycoreFinalProject.Data.Model;
using PaycoreFinalProject.Controllers;
using Microsoft.AspNetCore.Authorization;

namespace PaycoreFinalProjectAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : BaseController<ProductDto, Product>
    {
        private readonly IProductService productService;
        private readonly IMapper mapper;
        public ProductController(IProductService productService, IMapper mapper) : base(productService, mapper)
        {
            this.productService = productService;
            this.mapper = mapper;
        }

        [HttpGet("GetOffer")]
        public BaseResponse<IEnumerable<ProductDto>> GetOffer(int offerId)
        {
            var response = productService.GetOffer(offerId);
            return response;
        }
    }
}
