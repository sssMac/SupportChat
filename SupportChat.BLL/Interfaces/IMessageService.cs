using SupportChat.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportChat.BLL.Interfaces
{
    public interface IMessageService
    {
        public IEnumerable<Message> GetChatHistory();
        public IEnumerable<Message> GetMessageHistory(string userName);
        public Message GetMessageById(Guid id);
        public Message AddMessage(Message message);
        public Message UpdateMessage(Message message);
        public bool DeleteMessage(Guid id);
    }
}
