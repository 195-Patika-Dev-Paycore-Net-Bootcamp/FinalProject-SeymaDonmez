using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using PaycoreFinalProject.Data.Model;
using PaycoreFinalProject.Service.Abstract;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaycoreFinalProject.Service.Concrete
{
    public class RabbitMQService : IRabbitMQService
    {
        private IConfiguration _configuration;
        public ConnectionFactory _factory { get; private set; }
        public RabbitMQService(IConfiguration configuration)
        {
            _configuration = configuration;
            _factory = new ConnectionFactory() { HostName = "localhost" };

        }

        public void Publish(MailRequest mailRequest)
        {
            IConnection connection = _factory.CreateConnection();
            IModel channel = connection.CreateModel();

            channel.QueueDeclare("Mails", false, false, false, null);
            var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(mailRequest, formatting: Formatting.Indented));

            channel.BasicPublish("", "Mails", null, body);
        }

        public IConnection GetRabbitMQConnection()
        {
            ConnectionFactory connectionFactory = new ConnectionFactory()
            {
                // RabbitMQ bağlantısı kuracağı host tanımlanır. 
                HostName = "localhost"
            };

            return connectionFactory.CreateConnection();
        }
    }
}
