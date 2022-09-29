using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SupportChat.RabbitMQ
{
	public class RabbitMqService : IRabbitMqService
	{

        public bool SendMessage<T>(T message)
        {
            try
            {
                var factory = new ConnectionFactory() { HostName = "localhost" };
                using (var connection = factory.CreateConnection())
                {
                    using (var channel = connection.CreateModel())
                    {
                        channel.QueueDeclare(queue: "SupportChat",
                                     durable: true,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                        var json = JsonConvert.SerializeObject(message);
                        var messageBody = Encoding.UTF8.GetBytes(json);

                        channel.BasicPublish(exchange: "", routingKey: "SupportChat", body: messageBody, basicProperties: null);
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message} | {ex.StackTrace}");
                return false;
            }
        }
	}
}
