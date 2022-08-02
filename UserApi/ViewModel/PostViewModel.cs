using UserApi.Repo;

namespace UserApi.ViewModel
{
    public class PostViewModel : BaseModel
    {
      
        public string? Title { get; set; }
        public int UserID { get; set; }
    }
}
