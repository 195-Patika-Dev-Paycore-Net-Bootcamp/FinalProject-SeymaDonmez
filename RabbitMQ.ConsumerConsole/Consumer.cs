using PaycoreFinalProject.Data.Model;
using PaycoreFinalProject.Service.Abstract;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using System.Text.Json;
using System.Threading;
namespace RabbitMQ.ConsumerConsole
{
    public class Consumer
    {
        private readonly IRabbitMQService _rabbitMQService;
        private readonly IEmailService _emailService;


        public Consumer(string queueName, IRabbitMQService rabbitMQService,IEmailService emailService)
        {
            _rabbitMQService = rabbitMQService;
            _emailService = emailService;

            using (var connection = _rabbitMQService.GetRabbitMQConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    var consumer = new EventingBasicConsumer(channel);
                    // Received event'i sürekli listen modunda olacaktır.
                    consumer.Received += (model, ea) =>
                    {
                        var body = ea.Body;
                        var message = JsonSerializer.Deserialize<MailRequest>(Encoding.UTF8.GetString(ea.Body.ToArray()));                        
                        _emailService.SendEmailAsync(message);

                        Thread.Sleep(2000);
                        Console.WriteLine("{0} isimli queue üzerinden gelen mesaj: \"{1}\"", queueName, message);

                    };

                    
                    channel.BasicConsume(queueName, true, consumer);
                    Console.ReadLine();
                }
            }
        }
    }
}
