using AutoMapper;
using NHibernate;
using PaycoreFinalProject.Base.Response;
using PaycoreFinalProject.Data.Model;
using PaycoreFinalProject.Data.Repository;
using PaycoreFinalProject.Dto.DTOs;
using PaycoreFinalProject.Service.Abstract;
using Serilog;
using System;
using PaycoreFinalProject.Base.Utilities.Security;
using PaycoreFinalProject.Service.ValidationRules.FluentValidation;
using FluentValidation;
using PaycoreFinalProject.Service.Constants;
using PaycoreFinalProject.Base.Token;
using FluentValidation.Results;

namespace PaycoreFinalProject.Service.Concrete
{
    public class AuthService : IAuthService
    {
        private readonly ISession session;
        private readonly IMapper mapper;
        private readonly IHibernateRepository<User> hibernateRepository;
        private readonly IUserService userService;
        private readonly ITokenService tokenService;

        public AuthService(ISession session, IMapper mapper,IUserService userService, ITokenService tokenService)
        {
            this.session = session;
            this.mapper = mapper;
            this.userService = userService;
            this.tokenService = tokenService;

            hibernateRepository = new HibernateRepository<User>(session);

        }

        public IDataResult<UserForRegisterDto> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            var userEmailCheck = userService.GetByEmail(userForRegisterDto.Email);
            var userNameCheck = userService.GetByUserName(userForRegisterDto.UserName);

            if((userEmailCheck != null) || (userNameCheck!=null))
            {
                return new ErrorDataResult<UserForRegisterDto>(Messages.UserExists);
            }
            var userToCheck = mapper.Map<UserForRegisterDto, User>(userForRegisterDto);

            UserValidator userValidator = new UserValidator();
            ValidationResult results = userValidator.Validate(userToCheck);

            if(!results.IsValid)
            {
                return new ErrorDataResult<UserForRegisterDto>(Messages.UserValidationError);
            }

            try
            {
                var currentPassword = HashingHelper.CreatePasswordHash(userForRegisterDto.Password, userForRegisterDto.Email);
                userToCheck.Password = currentPassword;

                hibernateRepository.BeginTransaction();
                hibernateRepository.Save(userToCheck);
                hibernateRepository.Commit();

                hibernateRepository.CloseTransaction();

                return new SuccessDataResult<UserForRegisterDto>(mapper.Map<User, UserForRegisterDto>(userToCheck), Messages.SuccessfulLogin);
            }
            catch (Exception ex)
            {
                Log.Error("BaseService.Insert", ex);
                hibernateRepository.Rollback();
                hibernateRepository.CloseTransaction();
                return new ErrorDataResult<UserForRegisterDto>(ex.Message);
            }
        }

        public IDataResult<TokenResponse> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = userService.GetByEmail(userForLoginDto.Email);

            UserValidator userValidator = new UserValidator();
            userValidator.Validate(userToCheck);

            if (userToCheck == null)
            {
                return new ErrorDataResult<TokenResponse>(Messages.EmailOrPasswordError);
            }

            var verifyPassword = HashingHelper.CreatePasswordHash(userForLoginDto.Password, userForLoginDto.Email);

            if (!HashingHelper.VerifyPasswordHash(verifyPassword,userToCheck.Password))
            {
                return new ErrorDataResult<TokenResponse>(Messages.EmailOrPasswordError);
            }

            var tokenResponse = tokenService.GenerateToken(userToCheck);

            if (tokenResponse.Success)
            {
                return new SuccessDataResult<TokenResponse>(tokenResponse.Response,Messages.SuccessfulLogin);
            }
            return new ErrorDataResult<TokenResponse>(Messages.EmailOrPasswordError);
        }

        public IResult UserExists(string email,string userName)
        {
            if ((userService.GetByEmail(email) != null) || (userService.GetByUserName(userName)!=null))
            {
                return new ErrorResult("User already exists");
            }
            return new SuccessResult();
        }

    }
}
