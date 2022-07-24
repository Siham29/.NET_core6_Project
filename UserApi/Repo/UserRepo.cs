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
                Users = _context.Set<User>().ToList();
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
                Users = _context.Find<User>(id);
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
                _context.Remove<User>(_temp);
                _context.SaveChanges();



            }
        }
        public void Add(User user)
        {

            _context.Add<User>(user);


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

                _context.Update<User>(_temp);
                _context.SaveChanges();

            }


        }

    }
}
