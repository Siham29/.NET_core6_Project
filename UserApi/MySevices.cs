using UserApi.Repo;

namespace UserApi
{
    public static class MySevices
    {
        public static void InitServices(this IServiceCollection services)
        {

            services.AddScoped<IUserRepo, UserRepo>();
            services.AddScoped<IPostRepo, PostRepo>();


        }

    }
}
