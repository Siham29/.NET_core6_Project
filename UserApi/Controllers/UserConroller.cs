using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserApi.Repo;
using UserApi.Models;

namespace UserApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserConroller : ControllerBase
    {

        [HttpGet]

        public ActionResult<List<User>> GetAll() {
            return UserRepo.GetAll();
        
        
        }
        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {

            var user = UserRepo.Get(id);
            if(user == null)

                    return NotFound();
            return user;
 
        }
        [HttpDelete("{id}")]

        public ActionResult Deletet(int id)
        {

            var user1 = UserRepo.Get(id);
            if (user1 == null)

                return NotFound();
            UserRepo.delete(id);
            return Ok();

        }
        [HttpPost]
        public ActionResult Create (User user)
        {
            if (UserRepo.GetAll().Any(a => a.Id == user.Id))//check if the id is already exist
            return BadRequest();    

                UserRepo.add(user);
            return Ok();


        }
        [HttpPut]
        public ActionResult Update(User user)
        {
            var E = UserRepo.Get(user.Id);
            if (E == null)
                return NotFound();
            UserRepo.update(user.Id,user);
            return Ok();


        }

    }
}
