using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
namespace UserApi.Models
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions options) : base(options) { }
        DbSet<User> Users
        {
            get;
            set;
        }
    }
}