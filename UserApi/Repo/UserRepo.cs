using Microsoft.AspNetCore.Mvc;
using UserApi.Models;
using UserApi.ViewModels;

namespace UserApi.Repo
{
    public class UserRepo:IUserRepo
    {   
       private  List <User> Users { get; set; }
        private UserContext _context;

        public UserRepo(UserContext context)
        {

            _context = context;

           
        }
        
     
        public List<User> GetAll() {
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
        public User Get(int id) {

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

    
        public ResponseModel delete(int id)
        {
            ResponseModel model = new ResponseModel();
            try
            {
                User _temp = Get(id);
                if (_temp != null)
                {
                    _context.Remove<User>(_temp);
                    _context.SaveChanges();
                    model.IsSuccess = true;
                    model.Messsage = "User Deleted Successfully";
                }
                else
                {
                    model.IsSuccess = false;
                    model.Messsage = "User Not Found";
                }
            }
            catch (Exception ex)
            {
                model.IsSuccess = false;
                model.Messsage = "Error : " + ex.Message;
            }
            return model;
        }
        public ResponseModel AddAndUpdate(User user) {



            ResponseModel model = new ResponseModel();
            try
            {
                User _temp = Get(user.Id);
                if (_temp != null)
                {
                   
                    _temp.Id=user.Id;
                    _temp.FirstName= user.FirstName;
                    _temp.LastName= user.LastName;
                    
                    _context.Update<User>(_temp);
                    model.Messsage = "User Update Successfully";
                }
                else
                {
                   
                    _context.Add<User>(user);
                    model.Messsage = "User Inserted Successfully";
                }
                
                _context.SaveChanges();
                model.IsSuccess = true;
            }
            catch (Exception ex)
            {
                model.IsSuccess = false;
                model.Messsage = "Error : " + ex.Message;
            }
            return model;
        }

    
        //public  void update(int id ,User user)
        //{

        //    var index = Users.FindIndex(u => u.Id == user.Id);
        //    if (index == -1)
        //        return;
        //    Users[index] = user; 
        //}

    }

}
