using SupportChat.BLL.Interfaces;
using SupportChat.DAL.EF;
using SupportChat.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportChat.BLL.Services
{
    internal class UserService : IUserService
    {
        private readonly ApplicationContext _db;

        public UserService(ApplicationContext db)
        {
            _db = db;
        }
        public IEnumerable<User> GetUserList()
        {
            return _db.Users.ToList();
        }

        public User AddUser(User user)
        {
            var result = _db.Users.Add(user);
            _db.SaveChanges();
            return result.Entity;
        }

        public bool DeleteUser(Guid id)
        {
            var filteredData = _db.Users.Where(x => x.UserId == id).FirstOrDefault();
            var result = _db.Remove(filteredData);
            _db.SaveChanges();
            return result != null ? true : false;
        }

       
    }
}
