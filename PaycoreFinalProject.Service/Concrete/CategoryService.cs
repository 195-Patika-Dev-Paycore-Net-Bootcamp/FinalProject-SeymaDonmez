using AutoMapper;
using NHibernate;
using PaycoreFinalProject.Data.Repository;
using PaycoreFinalProject.Dto.DTOs;
using PaycoreFinalProject.Service.Base.Concrete;
using PaycoreFinalProject.Service.Abstract;
using PaycoreFinalProject.Data.Model;


namespace PaycoreFinalProject.Service.Concrete
{
    public class CategoryService : BaseService<CategoryDto, Category>, ICategoryService
    {
        private readonly ISession session;
        private readonly IMapper mapper;
        private readonly IHibernateRepository<Category> hibernateRepository;

        public CategoryService(ISession session, IMapper mapper) : base(session, mapper)
        {
            this.session = session;
            this.mapper = mapper;

            hibernateRepository = new HibernateRepository<Category>(session);
        }
    }
}
