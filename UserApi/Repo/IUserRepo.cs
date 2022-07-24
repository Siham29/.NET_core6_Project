using Microsoft.AspNetCore.Mvc;
using UserApi.Models;
using UserApi.ViewModels;

namespace UserApi.Repo
{
    public interface IUserRepo
    {
        public List<User> GetAll();
        public User Get(int id);
        public void delete(int id);
        public void Add(User user);
       
        public void Update( User user);
     
     


    }
}