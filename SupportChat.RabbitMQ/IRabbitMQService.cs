using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportChat.RabbitMQ
{
	public interface IRabbitMqService
	{
		public bool SendMessage<T>(T message);
	}
}
