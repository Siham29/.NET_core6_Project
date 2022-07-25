using Microsoft.AspNetCore.Mvc;
using UserApi.Models;
using UserApi.ViewModels;

namespace UserApi.Repo
{
    public class UserRepo : IUserRepo
    {
        private List<User> Users { get; set; }
        private UserContext _context;

        public UserRepo(UserContext context)
        {

            _context = context;


        }


        public List<User> GetAll()
        {
            List<User> Users;
            try
            {
                Users = _context.Users.ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return Users;
        }
        public User Get(int id)
        {

            User Users;
            try
            {
                Users = _context.Users.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            return Users;
        }


        public void delete(int id)
        {


            User _temp = Get(id);
            if (_temp != null)
            {
                _context.Users.Remove
                    (_temp);
                _context.SaveChanges();



            }
        }
        public void Add(User user)
        {

            _context.Users.Add(user);


            _context.SaveChanges();

        }


        public void Update(User user)
        {


            User _temp = Get(user.Id);
            if (_temp != null)
            {

                _temp.Id = user.Id;
                _temp.FirstName = user.FirstName;
                _temp.LastName = user.LastName;
                _temp.Posts=user.Posts; 

                _context.Users.Update(_temp);
                _context.SaveChanges();

            }


        }

    }



    //--------------------------------------------------------------------------------------------------------------------

    public class PostRepo : IPostRepo
    {
        private List<Post> Posts { get; set; }
        private UserContext _context;

        public PostRepo(UserContext context)
        {

            _context = context;
                  }


        public List<Post> GetAll()
        {
            List<Post> Posts;
            try
            {
                Posts = _context.Posts.ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return Posts;
        }
        public Post Get(int id)
        {

            Post Posts;
            try
            {
                Posts = _context.Posts.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            return Posts;
        }


        public void delete(int id)
        {


            Post _temp = Get(id);
            if (_temp != null)
            {
                _context.Posts.Remove(_temp);
                _context.SaveChanges();



            }
        }
        public void Add(Post Posts)
        {

            _context.Posts.Add(Posts);


            _context.SaveChanges();

        }


        public void Update(Post Posts)
        {


            Post _temp = Get(Posts.Id);
            if (_temp != null)
            {

                _temp.Id = Posts.Id;
                _temp.Title = Posts.Title;
                _temp.User = Posts.User;

                _context.Posts.Update(_temp);
                _context.SaveChanges();

            }


        }

    }
}
