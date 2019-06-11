using System.Security.Cryptography;

namespace Daily.Core
{
    public class Users
    {
        public long UserId { get; set; }
        public string UserName { get; set; }
        public MD5 UserPassword { get; set; }
    }
}
