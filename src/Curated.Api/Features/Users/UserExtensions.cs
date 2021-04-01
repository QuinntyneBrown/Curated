using System;
using Curated.Api.Models;

namespace Curated.Api.Features
{
    public static class UserExtensions
    {
        public static UserDto ToDto(this User user)
        {
                return new ()
                {
                    UserId = user.UserId
                };
        }
        
    }
}
