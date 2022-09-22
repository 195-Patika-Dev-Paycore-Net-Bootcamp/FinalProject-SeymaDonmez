using AutoMapper;
using NHibernate;
using PaycoreFinalProject.Base.Response;
using PaycoreFinalProject.Data.Model;
using PaycoreFinalProject.Data.Repository;
using PaycoreFinalProject.Dto.DTOs;
using PaycoreFinalProject.Service.Abstract;
using PaycoreFinalProject.Service.ValidationRules.FluentValidation;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PaycoreFinalProject.Service.Concrete
{
    
    public class UserService : IUserService
    {
        protected readonly ISession session;
        protected readonly IMapper mapper;
        protected readonly IHibernateRepository<User> hibernateRepository;
        public UserService(ISession session, IMapper mapper) 
        {
            this.session = session;
            this.mapper = mapper;

            hibernateRepository = new HibernateRepository<User>(session);
        }

        public virtual BaseResponse<UserDto> Create(UserDto user)
        {
            try
            {
                var tempEntity = mapper.Map<UserDto, User>(user);

                hibernateRepository.BeginTransaction();
                hibernateRepository.Save(tempEntity);
                hibernateRepository.Commit();

                hibernateRepository.CloseTransaction();
                return new BaseResponse<UserDto>(mapper.Map<User, UserDto>(tempEntity));
            }
            catch (Exception ex)
            {
                Log.Error("BaseService.Create", ex);
                hibernateRepository.Rollback();
                hibernateRepository.CloseTransaction();
                return new BaseResponse<UserDto>(ex.Message);
            }

        }

        // Offers received by the user for their products
        public virtual BaseResponse<IEnumerable<UserDetailDto>> GetOffersByUserId(int userId)
        {
            try
            {
                var tempEntity = hibernateRepository.Where(x => x.Offers.Any(o => o.UserId == userId)).ToList();

                if (tempEntity is null)
                {
                    return new BaseResponse<IEnumerable<UserDetailDto>>("Record Not Found");
                }

                var result = mapper.Map<IEnumerable<User>, IEnumerable<UserDetailDto>>(tempEntity);               
                return new BaseResponse<IEnumerable<UserDetailDto>>(result);
            }
            catch (Exception ex)
            {
                Log.Error("UserService.GetOffersByOfferId", ex);
                return new BaseResponse<IEnumerable<UserDetailDto>>(ex.Message);
            }
        }


        public BaseResponse<UserDetailDto> GetById(int id)
        {
            try
            {
                var tempEntity = hibernateRepository.GetById(id);
                var result = mapper.Map<User, UserDetailDto>(tempEntity);
                return new BaseResponse<UserDetailDto>(result);
            }
            catch (Exception ex)
            {
                Log.Error("BaseService.GetById", ex);
                return new BaseResponse<UserDetailDto>(ex.Message);
            }
        }

        public BaseResponse<IEnumerable<UserDetailDto>> GetAll()
        {
            try
            {
                var tempEntity = hibernateRepository.Entities.ToList();
                var result = mapper.Map<IEnumerable<User>, IEnumerable<UserDetailDto>>(tempEntity);
                return new BaseResponse<IEnumerable<UserDetailDto>>(result);
            }
            catch (Exception ex)
            {
                Log.Error("BaseService.GetAll", ex);
                return new BaseResponse<IEnumerable<UserDetailDto>>(ex.Message);
            }
        }

        public BaseResponse<UserDto> Update(int id, UserDto updateResource)
        {
            try
            {
                var tempEntity = hibernateRepository.GetById(id);
                if (tempEntity is null)
                {
                    return new BaseResponse<UserDto>("Record Not Found");
                }


                var entity = mapper.Map<UserDto, User>(updateResource, tempEntity);

                hibernateRepository.BeginTransaction();
                hibernateRepository.Update(entity);
                hibernateRepository.Commit();
                hibernateRepository.CloseTransaction();

                var resource = mapper.Map<User, UserDto>(entity);
                return new BaseResponse<UserDto>(resource);
            }
            catch (Exception ex)
            {
                Log.Error("BaseService.Update", ex);
                hibernateRepository.Rollback();
                hibernateRepository.CloseTransaction();
                return new BaseResponse<UserDto>(ex.Message);
            }
        }

        public BaseResponse<UserDto> Remove(int id)
        {
            try
            {
                var tempEntity = hibernateRepository.GetById(id);
                if (tempEntity is null)
                {
                    return new BaseResponse<UserDto>("Record Not Found");
                }

                hibernateRepository.BeginTransaction();
                hibernateRepository.Delete(id);
                hibernateRepository.Commit();
                hibernateRepository.CloseTransaction();

                return new BaseResponse<UserDto>(mapper.Map<User, UserDto>(tempEntity));
            }
            catch (Exception ex)
            {
                Log.Error("BaseService.Remove", ex);
                hibernateRepository.Rollback();
                hibernateRepository.CloseTransaction();
                return new BaseResponse<UserDto>(ex.Message);
            }
        }

        public User GetByEmail(string email)
        {
            var result = hibernateRepository.Where(e=>e.Email==email).AsQueryable().FirstOrDefault();

            return result;
        }

        public User GetByUserName(string username)
        {
            var result = hibernateRepository.Where(u => u.UserName == username).AsQueryable().FirstOrDefault();

            return result;
        }
    }
}
      