using AutoMapper;
using UserApi.Models;

namespace UserApi.ViewModel
{
    public class MapConigration : Profile
    {
        
            public MapConigration()
            {
                CreateMap<User, UserViewModel>().ReverseMap();
                CreateMap<Post, PostViewModel>().ReverseMap();

            }

        }
    
}
