using Microsoft.EntityFrameworkCore;
using UserApi.Models;


namespace UserApi.Repo
{
    public class UserRepo : GenercicRepo<User>, IUserRepo
    { 
        public UserRepo(UserContext context) : base(context)
        {
        }
        public async Task < List<User>>? GetAll()
        {
            return _context.Users.Include(c => c.Posts).ToList();

        }

    }



    //--------------------------------------------------------------------------------------------------------------------

    public class PostRepo : GenercicRepo<Post>, IPostRepo
    {
        public PostRepo(UserContext context) : base(context)
        {
        }
        public async Task <List<Post>>? GetAll()
        {
            return _context.Posts.Include(c => c.User).ToList();

        }
    }
}
