using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaycoreFinalProject.Data.Model;
using RabbitMQ.Client;

namespace PaycoreFinalProject.Service.Abstract
{
    public interface IRabbitMQService
    {
        public void Publish(MailRequest mailRequest);
        IConnection GetRabbitMQConnection();
    }
}
