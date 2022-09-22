using PaycoreFinalProject.Base.Response;
using PaycoreFinalProject.Base.Token;
using PaycoreFinalProject.Data.Model;
using PaycoreFinalProject.Dto.DTOs;
using System.Collections.Generic;

namespace PaycoreFinalProject.Service.Abstract
{
    public interface IAuthService
    {
        IDataResult<UserForRegisterDto> Register(UserForRegisterDto userForRegisterDto, string password);
        IDataResult<TokenResponse> Login(UserForLoginDto userForLoginDto);
        IResult UserExists(string email, string userName);
    }
}
