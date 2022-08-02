using Microsoft.AspNetCore.Identity;

namespace JWTAuthentication.NET6._0.Auth
{
    public  class UserRoles:IdentityRole<int>
    {
        public const string Admin = "Admin";
        public const string User = "User";
    }
}