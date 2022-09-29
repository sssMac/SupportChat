using SupportChat.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportChat.BLL.Interfaces
{
    public interface IUserService
    {
        public IEnumerable<User> GetUserList();
        public User AddUser (User user);
        public bool DeleteUser(Guid id);
    }
}
