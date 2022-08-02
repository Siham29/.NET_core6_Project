using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using UserApi.Repo;

namespace UserApi.Models
{
    public class User: IdentityUser<int>, IBaseModel
    {
        

        public string  FirstName { get; set; }
        public string  LastName { get; set; }

        public ICollection<Post> ? Posts { get; set; }

    }
}
