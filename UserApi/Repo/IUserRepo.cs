using Microsoft.AspNetCore.Mvc;
using UserApi.Models;
using UserApi.ViewModels;

namespace UserApi.Repo
{
    public interface IUserRepo
    {
        public List<User> GetAll();
        public User Get(int id);
        public ResponseModel delete(int id);
        public ResponseModel AddAndUpdate(User user);
       
       // public void update(int id, User user);
     
     


    }
}