using Microsoft.AspNetCore.Identity;

namespace JWTAuthServer.Core.Models
{
    public class UserApp:IdentityUser
    {
        public string? City { get; set; }
    }
}
