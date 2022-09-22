using System;
using System.Net.Http;
using Xunit;
using Moq;
using System.Collections.Generic;
using PaycoreFinalProject.Service.Abstract;
using PaycoreFinalProject.Data.Repository;
using PaycoreFinalProjectAPI.Controllers;
using PaycoreFinalProject.Data.Model;
using AutoMapper;
using PaycoreFinalProject.Dto.DTOs;
using PaycoreFinalProject.Base.Response;
using PaycoreFinalProject.Service.Mapper;
using PaycoreFinalProject.Service.Concrete;

namespace PaycoreFinalProject.Test
{
    public class CategoryControllerTest
    {
        private readonly HttpClient _client;

        private readonly Mock<IHibernateRepository<Category>> _mockRepo;
        private readonly CategoryController _controller;
        private readonly IMapper _mapper;

        public CategoryControllerTest()
        {
            var mapperConfiguration = new MapperConfiguration(c => c.AddProfile(new MappingProfile()));
            IMapper mapper = new Mapper(mapperConfiguration);

            var categoryService = new Mock<ICategoryService>();
            _client = new HttpClient();
            _mockRepo = new Mock<IHibernateRepository<Category>>();

             _controller = new CategoryController(categoryService.Object,mapper);


            _mockRepo.Setup(repo => repo.GetAll()).Returns(new List<Category>() { new Category {CategoryId=1, CategoryName = "Speciality" }, new Category {CategoryId=2, CategoryName = "Shopping" } });


        }
        [Fact]
        public void Category_GetAll_CategoryList()
        {
            
            var result = _controller.GetAll();

            var viewResult= Assert.IsType<List<Category>>(result);
            Assert.Equal(2, viewResult.Count);
        }
    }
}
