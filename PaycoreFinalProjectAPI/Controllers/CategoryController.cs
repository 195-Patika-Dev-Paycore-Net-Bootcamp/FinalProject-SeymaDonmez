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
    public class CategoryController : BaseController<CategoryDto, Category>
    {
        private readonly ICategoryService categoryService;
        private readonly IMapper mapper;
        public CategoryController(ICategoryService categoryService, IMapper mapper) : base(categoryService, mapper)
        {
            this.categoryService = categoryService;
            this.mapper = mapper;
        }
    }
}
