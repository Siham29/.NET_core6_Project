using UserApi.Models;

namespace UserApi.Repo
{
    public interface IPostRepo : IGenercicRepo<Post>
    {
        Task<List<Post>> Search(int page, int size, string title);
    }
}