using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SupportChat.BLL.Interfaces;
using SupportChat.DAL.Entity;
using SupportChat.RabbitMQ;

namespace SupportChat.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly IMessageService _messageService;
        private readonly IRabbitMqService _rabitMqService;
        public ChatController(IMessageService messageService, IRabbitMqService rabitMqService)
        {
            _messageService = messageService;
            _rabitMqService = rabitMqService;
        }

        [HttpGet("chathistory")]
        public IEnumerable<Message> GetChatHistory()
        {
            var mesageList = _messageService.GetChatHistory();
            return mesageList;
        }

        [HttpGet("messagehistory")]
        public IEnumerable<Message> GetMessageHistory(string userName)
        {
            var userMesageList = _messageService.GetMessageHistory(userName);
            return userMesageList;
        }

        [HttpGet("getmessagebyid")]
        public Message GetMessageById(Guid id)
        {
            return _messageService.GetMessageById(id);
        }

        [HttpPost("addmessage")]
        public Message AddMessage(Message message)
        {
            var mesageData = _messageService.AddMessage(new Message
            {
                MessageId = Guid.NewGuid(),
                UserName = message.UserName,
                Text = message.Text,
                PublishDate = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds()
        });

            _rabitMqService.SendMessage(mesageData);
            return mesageData;

        }

        [IgnoreAntiforgeryToken]
        [HttpPut("updatemessage")]
        public Message UpdateMessage(Message message)
        {
            return _messageService.UpdateMessage(message);
        }

        [HttpDelete("deletemessage")]
        public bool DeleteMessage(Guid id)
        {
            return _messageService.DeleteMessage(id);
        }
    }
}

