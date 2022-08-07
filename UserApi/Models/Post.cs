
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

        public DateTime CreationDate { get; set; }

        public int CreatedBy { get; set; }

        public DateTime UpdateDate { get; set; }
        public int UpdatedBy { get; set; }



    }
}
