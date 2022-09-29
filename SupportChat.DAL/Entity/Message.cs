using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportChat.DAL.Entity
{
    public class Message
    {
        public Guid MessageId { get; set; }
        public string UserName { get; set; }
        public string Text { get; set; }
        public long PublishDate { get; set; }
    }
}
