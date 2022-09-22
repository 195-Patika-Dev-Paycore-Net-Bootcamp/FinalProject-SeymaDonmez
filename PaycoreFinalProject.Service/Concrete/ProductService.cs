using AutoMapper;
using NHibernate;
using PaycoreFinalProject.Data.Repository;
using PaycoreFinalProject.Dto.DTOs;
using PaycoreFinalProject.Service.Base.Concrete;
using PaycoreFinalProject.Service.Abstract;
using PaycoreFinalProject.Data.Model;
using PaycoreFinalProject.Base.Response;
using System.Collections.Generic;
using System.Linq;
using System;
using PaycoreFinalProject.Service.ValidationRules.FluentValidation;
using PaycoreFinalProject.Service.Constants;
using Serilog;

namespace PaycoreFinalProject.Service.Concrete
{
    public class ProductService : BaseService<ProductDto, Product>, IProductService
    {
        private readonly ISession session;
        private readonly IMapper mapper;
        private readonly IHibernateRepository<Product> hibernateRepository;

        public ProductService(ISession session, IMapper mapper) : base(session, mapper)
        {
            this.session = session;
            this.mapper = mapper;

            hibernateRepository = new HibernateRepository<Product>(session);
        }


        public BaseResponse<IEnumerable<ProductDto>> GetOffer(int offerId)
        {
            try
            {
                var tempEntity = hibernateRepository.Where(x => x.Offers.Any(o => o.OfferId == offerId)).ToList();

                if(tempEntity is null)
                {
                    return new BaseResponse<IEnumerable<ProductDto>>("Record Not Found");
                }

                var result = mapper.Map<IEnumerable<Product>, IEnumerable<ProductDto>>(tempEntity);
                return new BaseResponse<IEnumerable<ProductDto>>(result);
            }
            catch (Exception ex)
            {
                hibernateRepository.Rollback();
                hibernateRepository.CloseTransaction();
                return new BaseResponse<IEnumerable<ProductDto>>(ex.Message);
            }
        }
        public override BaseResponse<ProductDto> Update(int id, ProductDto updateResource)
        {
            try
            {

                var tempEntity = hibernateRepository.GetById(id);

                ProductValidator productValidator = new ProductValidator();
                productValidator.Validate(tempEntity);

                if (tempEntity == null)
                {
                    return new BaseResponse<ProductDto>(message: Messages.ProductInvalid);
                }

                if (tempEntity is null)
                {
                    return new BaseResponse<ProductDto>("Record Not Found");
                }


                var entity = mapper.Map<ProductDto, Product>(updateResource, tempEntity);

                hibernateRepository.BeginTransaction();
                hibernateRepository.Update(entity);
                hibernateRepository.Commit();
                hibernateRepository.CloseTransaction();

                var resource = mapper.Map<Product, ProductDto>(entity);
                return new BaseResponse<ProductDto>(resource);
            }
            catch (Exception ex)
            {
                Log.Error("BaseService.Update", ex);
                hibernateRepository.Rollback();
                hibernateRepository.CloseTransaction();
                return new BaseResponse<ProductDto>(ex.Message);
            }



        }
    }
}
