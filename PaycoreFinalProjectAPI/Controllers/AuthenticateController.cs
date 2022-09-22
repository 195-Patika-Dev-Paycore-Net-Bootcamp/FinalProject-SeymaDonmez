using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PaycoreFinalProject.Data.Model;
using PaycoreFinalProject.Dto.DTOs;
using PaycoreFinalProject.Service.Abstract;
using System.Threading.Tasks;

namespace PaycoreFinalProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly IAuthService authService;
        private readonly ITokenService tokenService;
        private readonly IMapper mapper;
        private readonly IEmailService emailService;

        public AuthenticateController(IUserService userService,IAuthService authService, ITokenService tokenService, IMapper mapper, IEmailService emailService)
        {
            this.userService = userService;
            this.authService = authService;
            this.tokenService = tokenService;
            this.mapper = mapper;
            this.emailService = emailService;
        }

        [HttpPost("login")]
        public IActionResult Login(UserForLoginDto userForLoginDto)
        {
            var result = authService.Login(userForLoginDto);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("register")]
        public ActionResult Register(UserForRegisterDto userForRegisterDto)
        {
            var userExists = authService.UserExists(userForRegisterDto.Email,userForRegisterDto.UserName);
            if (!userExists.Success)
            {
                return BadRequest(userExists.Message);
            }

            var registerResult = authService.Register(userForRegisterDto,userForRegisterDto.Password);

            if (!registerResult.Success)
            {
                return BadRequest(registerResult.Message);
            }
            MailRequest mail = new MailRequest() { Body = "Welcome!", Status = true, Subject = "Successfully registered", ToEmail = userForRegisterDto.Email };
            emailService.SendEmailAsync(mail);

            return Ok(registerResult);
        }
    }
}
