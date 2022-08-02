using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UserApi.Models;

namespace JWTAuthentication.NET6._0.Auth
{
    public class UserContext : IdentityDbContext<User,UserRoles,int>
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options) { }

        public DbSet<User> Users
        {
            get;
            set;
        }
        public DbSet<Post> Posts
        {
            get;
            set;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}