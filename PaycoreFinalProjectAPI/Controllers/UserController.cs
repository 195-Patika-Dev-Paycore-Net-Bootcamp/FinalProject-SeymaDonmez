using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PaycoreFinalProject.Base.Response;
using PaycoreFinalProject.Dto.DTOs;
using PaycoreFinalProject.Service.Abstract;
using System.Collections.Generic;

namespace PaycoreFinalProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly IMapper mapper;
        public UserController(IUserService userService, IMapper mapper)
        {
            this.userService = userService;
            this.mapper = mapper;
        }

        

        [HttpGet("GetOffersByUserId")]
        public BaseResponse<IEnumerable<UserDetailDto>> GetOffersByUserId(int userId)
        { 
            var response = userService.GetOffersByUserId(userId);
            return response;
        }


        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = userService.GetAll();

            if (!result.Success)
            {
                return BadRequest(result);
            }

            if (result.Response is null)
            {
                return NoContent();
            }

            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = userService.GetById(id);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            if (result.Response is null)
            {
                return NoContent();
            }

            return Ok(result);
        }

        [HttpPost("Create")]
        public virtual IActionResult Create([FromBody] UserDto user)
        {
            var result = userService.Create(user);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            if (result.Response is null)
            {
                return NoContent();
            }

            if (result.Success)
            {
                return StatusCode(201, result);
            }

            return BadRequest(result);
        }

        [HttpPut("{id}")]
        public virtual IActionResult Update(int id, [FromBody] UserDto dto)
        {
            var result = userService.Update(id, dto);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            if (result.Response is null)
            {
                return NoContent();
            }

            if (result.Success)
            {
                return StatusCode(200, result);
            }

            return BadRequest(result);
        }

        [HttpDelete]
        public virtual IActionResult Delete(int id)
        {
            var result = userService.Remove(id);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


    }
}

