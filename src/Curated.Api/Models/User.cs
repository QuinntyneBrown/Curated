using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;

namespace Curated.Api.Models
{
    public class User
    {
        [Key]
        public Guid UserId { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }
        public string RefreshToken { get; private set; }
        public byte[] Salt { get; private set; }
        public User()
        {
            Salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(Salt);
            }
        }

        public User AddRefreshToken(string token)
        {
            RefreshToken = token;
            return this;
        }
    }
}
