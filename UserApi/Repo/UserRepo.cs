using AutoMapper;
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
