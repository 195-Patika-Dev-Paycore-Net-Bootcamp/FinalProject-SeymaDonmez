using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PaycoreFinalProject.Service.Abstract;
using PaycoreFinalProject.Service.Concrete;
using PaycoreFinalProject.Service.Mapper;
using System;


namespace PaycoreFinalProjectAPI.StartUpExtension
{
    public static class ExtensionService
    {

        public static void AddServices(this IServiceCollection services)
        {
            // services 
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IOfferService, OfferService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<PaycoreFinalProject.Service.Abstract.IEmailService, PaycoreFinalProject.Service.Concrete.MailService>();
            services.AddScoped<IRabbitMQService, RabbitMQService>();





            // mapper
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            services.AddSingleton(mapperConfig.CreateMapper());
        }
    }
}
