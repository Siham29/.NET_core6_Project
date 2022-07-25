using System.ComponentModel.DataAnnotations;

namespace UserApi.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string  FirstName { get; set; }
        public string  LastName { get; set; }

        public ICollection<Post> ? Posts { get; set; }

    }
}
