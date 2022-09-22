using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaycoreFinalProject.Controllers;
using PaycoreFinalProject.Data.Model;
using PaycoreFinalProject.Dto.DTOs;
using PaycoreFinalProject.Service.Abstract;

namespace PaycoreFinalProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfferController : BaseController<OfferDto, Offer>
    {
        private readonly IOfferService offerService;
        private readonly IMapper mapper;
        public OfferController(IOfferService offerService, IMapper mapper) : base(offerService, mapper)
        {
            this.offerService = offerService;
            this.mapper = mapper;
        }


    }
}
