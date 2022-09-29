﻿using SupportChat.BLL.Interfaces;
using SupportChat.DAL.EF;
using SupportChat.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportChat.BLL.Services
{
    public class MessageService : IMessageService
    {
        private readonly ApplicationContext _db;

        public MessageService(ApplicationContext db)
        {
            _db = db;
        }

        public IEnumerable<Message> GetChatHistory()
        {
            return _db.Messages.ToList();
        }

        public IEnumerable<Message> GetMessageHistory(string userName)
        {
            return _db.Messages.Where(m => m.UserName == userName).ToList();
        }

        public Message GetMessageById(Guid id)
        {
            return _db.Messages.Where(x => x.MessageId == id).FirstOrDefault();
        }

        public Message AddMessage(Message message)
        {
            var result = _db.Messages.Add(message);
            _db.SaveChanges();
            return result.Entity;
        }

        public Message UpdateMessage(Message message)
        {
            var result = _db.Messages.Update(message);
            _db.SaveChanges();
            return result.Entity;
        }

        public bool DeleteMessage(Guid id)
        {
            var filteredData = _db.Messages.Where(x => x.MessageId == id).FirstOrDefault();
            var result = _db.Remove(filteredData);
            _db.SaveChanges();
            return result != null ? true : false;
        }

    }
}
