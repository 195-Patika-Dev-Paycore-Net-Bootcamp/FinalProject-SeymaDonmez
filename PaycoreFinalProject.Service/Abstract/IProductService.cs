using PaycoreFinalProject.Data.Model;
using PaycoreFinalProject.Dto.DTOs;
using PaycoreFinalProject.Service.Base.Abstract;
using PaycoreFinalProject.Base.Response;
using System.Collections.Generic;

namespace PaycoreFinalProject.Service.Abstract
{
    public interface IProductService : IBaseService<ProductDto, Product>
    {
        BaseResponse<IEnumerable<ProductDto>> GetOffer(int offerId);
    }
}
