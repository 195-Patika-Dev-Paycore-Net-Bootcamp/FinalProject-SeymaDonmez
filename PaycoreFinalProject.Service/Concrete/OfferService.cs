using AutoMapper;
using NHibernate;
using PaycoreFinalProject.Data.Repository;
using PaycoreFinalProject.Dto.DTOs;
using PaycoreFinalProject.Service.Base.Concrete;
using PaycoreFinalProject.Service.Abstract;
using PaycoreFinalProject.Data.Model;
using PaycoreFinalProject.Base.Response;
using System;
using Serilog;
using System.Linq;
using System.Collections.Generic;

namespace PaycoreFinalProject.Service.Concrete 
{
    public class OfferService : BaseService<OfferDto, Offer>, IOfferService
    {
        private readonly ISession session;
        private readonly IMapper mapper;
        private readonly IHibernateRepository<Offer> hibernateRepositoryOffer;
        private readonly IHibernateRepository<Product> hibernateRepositoryProduct;

        public OfferService(ISession session, IMapper mapper) : base(session, mapper)
        {
            this.session = session;
            this.mapper = mapper;

            hibernateRepositoryOffer = new HibernateRepository<Offer>(session);
            hibernateRepositoryProduct = new HibernateRepository<Product>(session);
        }
        // Give an offer: Product's isOfferable value is true, than user can buy the product 
        public override BaseResponse<OfferDto> Insert(OfferDto insertResource)
        {
            try
            {
                var offer = mapper.Map<OfferDto, Offer>(insertResource);

                var tempEntity = hibernateRepositoryProduct.Entities.FirstOrDefault();
                var result = hibernateRepositoryOffer.Where(o =>o.ProductId == tempEntity.ProductId).AsQueryable().FirstOrDefault();
                var offerProduct = offer.Product;


                if((offerProduct is not null) && (offerProduct.IsOfferable=true))
                {
                    //Kullanıcı teklif yapmadan bir ürünü direk satın alabilir. Kullanıcı ürünü satın alınca,ilgili ürün datası içerisindeki isSold alanının değeri güncellenmeli
                    if (offer.OfferedPrice ==offerProduct.Price)
                    {
                        offerProduct.IsSold = true;
                        offerProduct.IsOfferable = false;
                    }

                    offer.Product = null;
                    hibernateRepositoryOffer.BeginTransaction();
                    hibernateRepositoryOffer.Save(offer);
                    hibernateRepositoryOffer.Commit();
                    hibernateRepositoryOffer.CloseTransaction();

                }

                offerProduct.Offers.Add(offer);
                hibernateRepositoryProduct.BeginTransaction();
                hibernateRepositoryProduct.Save(offerProduct);
                hibernateRepositoryProduct.Commit();
                hibernateRepositoryProduct.CloseTransaction();


                return new BaseResponse<OfferDto>(mapper.Map<Offer, OfferDto>(offer));
            }
            catch (Exception ex)
            {
                Log.Error("OfferService.Insert", ex);
                hibernateRepositoryOffer.Rollback();
                hibernateRepositoryOffer.CloseTransaction();
                return new BaseResponse<OfferDto>(ex.Message);
            }

        }

        //Offers received by the user for their products
        public virtual BaseResponse<IEnumerable<OfferDto>> GetOffersByUserId(int userId)
        {
            try
            {
                var tempEntity = hibernateRepository.Where(x => x.UserId == userId).AsQueryable().ToList();
                var result = mapper.Map<IEnumerable<Offer>, IEnumerable<OfferDto>>(tempEntity);
                return new BaseResponse<IEnumerable<OfferDto>>(result);
            }
            catch (Exception ex)
            {
                Log.Error("OfferService.GetOffersByOfferId", ex);
                return new BaseResponse<IEnumerable<OfferDto>>(ex.Message);
            }
        }

    }
}
