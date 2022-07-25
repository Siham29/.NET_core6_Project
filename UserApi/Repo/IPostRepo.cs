using UserApi.Models;

namespace UserApi.Repo
{
    public interface IPostRepo
    {


        public List<Post> GetAll();
        public Post Get(int id);
        public void delete(int id);
        public void Add(Post post);

        public void Update(Post post);



    }
}