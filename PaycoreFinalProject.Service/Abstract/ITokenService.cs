using PaycoreFinalProject.Base.Response;
using PaycoreFinalProject.Base.Token;
using PaycoreFinalProject.Data.Model;

namespace PaycoreFinalProject.Service.Abstract
{
    public interface ITokenService
    {
        BaseResponse<TokenResponse> GenerateToken(User tokenRequest);
    }
}
