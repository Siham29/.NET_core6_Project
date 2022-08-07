using AutoMapper;
using JWTAuthentication.NET6._0.Auth;

using UserApi.Models;


namespace UserApi.Repo
{
    public class UserRepo : GenercicRepo<User>, IUserRepo
    { 
        public UserRepo(UserContext context, IMapper mapper) : base(context, mapper)
        {
        }
     

    }



    //--------------------------------------------------------------------------------------------------------------------

    public class PostRepo : GenercicRepo<Post>, IPostRepo
    {
        public PostRepo(UserContext context, IMapper mapper) : base(context, mapper)
        {
        }
        public async Task<List<Post>>? Search(int page,int size,String title)
        {
            return _context.Posts.Where(c => c.Title.Contains(title)).Skip(page * size).Take(size).ToList();
        }

    }
}
