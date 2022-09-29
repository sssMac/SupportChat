using System.ComponentModel.DataAnnotations;

namespace SupportChat.DAL.Entity
{
    public class User
    {
        public Guid UserId { get; set; }

        [Key]
        public string UserName { get; set; }
    }
}
