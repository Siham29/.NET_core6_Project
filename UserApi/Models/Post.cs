using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserApi.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User ? User { get; set; }  

    }
}
