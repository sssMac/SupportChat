using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportChat.RabbitMQ.Hubs
{
    public class MessageHub : Hub
    {
        public async Task SendMessage(string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", message);
        }

        public async Task SendMQMessage(List<string> messages)
        {
            await Clients.All.SendAsync("ReceiveMQMessage", messages);
        }
    }
}
