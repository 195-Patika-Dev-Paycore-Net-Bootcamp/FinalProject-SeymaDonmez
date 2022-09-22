using PaycoreFinalProject.Base.Response;
using PaycoreFinalProject.Data.Model;
using PaycoreFinalProject.Dto.DTOs;
using System.Collections.Generic;

namespace PaycoreFinalProject.Service.Abstract
{
    public interface IUserService
    {
        BaseResponse<UserDetailDto> GetById(int id);
        BaseResponse<IEnumerable<UserDetailDto>> GetAll();
        BaseResponse<UserDto> Create(UserDto user);
        BaseResponse<UserDto> Update(int id, UserDto updateResource);
        BaseResponse<UserDto> Remove(int id);
        BaseResponse<IEnumerable<UserDetailDto>> GetOffersByUserId(int userId);
        User GetByEmail(string email);
        User GetByUserName(string username);
    }
}
