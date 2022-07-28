using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UserApi.Repo;

namespace UserApi.Models
{
    public class Post:BaseModel
    {
      
        public string Title { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User? User { get; set; }  

    }
}
