using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PaycoreFinalProject.Service.Abstract;
using PaycoreFinalProject.Service.Concrete;
using PaycoreFinalProject.Service.Mapper;
using RabbitMQ.Client;
using System;
using System.Configuration;

namespace RabbitMQ.ConsumerConsole
{
    internal class Program
    {
        public IConfiguration Configuration { get; }
        public Program(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        static void Main(string[] args)
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });


            ServiceProvider serviceProvider= new ServiceCollection().AddTransient<IRabbitMQService, RabbitMQService>().
                AddTransient<PaycoreFinalProject.Service.Abstract.IEmailService, PaycoreFinalProject.Service.Concrete.MailService>()
                .AddSingleton(mapperConfig.CreateMapper())
                                           .BuildServiceProvider();


            IConnection connection = serviceProvider.GetService<IConnection>();
            //IRabbitMQService rabbitMQService = serviceProvider.GetService<IRabbitMQService>();
            //IEmailService emailService = serviceProvider.GetService<IEmailService>();


            //Consumer consumer = new("Mails", rabbitMQService, emailService);

            //Console.WriteLine(connection.GetType());
            Console.ReadLine();
        }
    }
}
