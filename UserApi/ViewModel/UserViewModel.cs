using UserApi.Repo;

namespace UserApi.ViewModel
{
    public class UserViewModel:BaseModel
    {
        
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public ICollection<PostViewModel>? Posts { get; set; }
    }
}
