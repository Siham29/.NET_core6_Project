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
       
    }
}
