using UserApi.Models;
namespace UserApi.Repo
{
    public class UserRepo
    {
        static List <User> Users { get; set; }

        static UserRepo()
        {

            Users = new List<User>()
            {

                new User() { Id = 1, FirstName = "Mohammad",LastName = "Abu rmaileh"  },
                new User() { Id = 2, FirstName = "Osaid", LastName = "Abu rmaileh" }

              };
        }
        public static List<User> GetAll() { 
        return Users;
        }
        public static User Get(int id) {

            return Users.FirstOrDefault(user => user.Id == id);
        
        }
        public static void delete(int id)
        {
            var user1 =Get(id);
            if (user1 != null)
                Users.Remove(user1);



        }
        public static void add(User user) {
           


            Users.Add(user);
        
        }
        public static void update(int id ,User user)
        {

            var index = Users.FindIndex(u => u.Id == user.Id);
            if (index == -1)
                return;
            Users[index] = user;
        }

    }

}
