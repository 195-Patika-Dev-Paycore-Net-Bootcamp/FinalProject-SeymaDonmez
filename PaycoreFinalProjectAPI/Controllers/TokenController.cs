using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaycoreFinalProject.Base.Response;
using PaycoreFinalProject.Base.Token;
using PaycoreFinalProject.Service.Abstract;

namespace PaycoreFinalProjectAPI.Controllers
{
    [ApiController]
    [Route("api/nhb/[controller]")]
    public class TokenController : ControllerBase
    {
        private readonly ITokenService tokenService;

        public TokenController(ITokenService tokenService)
        {
            this.tokenService = tokenService;
        }

    }
}
