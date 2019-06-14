using System.Security.Cryptography;

namespace Daily.Core.Models
{
    public class Users : Entity
    {
        public long UserId { get; set; }
        public string UserName { get; set; }
        public MD5 UserPassword { get; set; }
    }
}
