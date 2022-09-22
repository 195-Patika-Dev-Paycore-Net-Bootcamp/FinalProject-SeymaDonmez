using PaycoreFinalProject.Base.Response;
using PaycoreFinalProject.Data.Model;
using PaycoreFinalProject.Dto.DTOs;
using PaycoreFinalProject.Service.Base.Abstract;
using System.Collections.Generic;

namespace PaycoreFinalProject.Service.Abstract
{
    public interface IOfferService : IBaseService<OfferDto, Offer>
    {
        public BaseResponse<IEnumerable<OfferDto>> GetOffersByUserId(int userId);
    }
}
