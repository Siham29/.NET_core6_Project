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
        private readonly IUserRepo _userRepo;

        public UserConroller(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        [HttpGet]

        public ActionResult<List<User>> GetAll()
        {
            return _userRepo.GetAll();


        }
        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {

            var user = _userRepo.Get(id);
            if (user == null)

                return NotFound();
            return user;

        }
        [HttpDelete("{id}")]

        public ActionResult Deletet(int id)
        {

            var user1 = _userRepo.Get(id);
            if (user1 == null)

                return NotFound();
            _userRepo.delete(id);
            return Ok();

        }
        [HttpPost]
        public ActionResult CreateAndUpdate(User user)
        {
            try
            {
                var model = _userRepo.AddAndUpdate(user);
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest();
            }


        }
        //[HttpPut]
        //public ActionResult Update(User user)
        //{
        //    var E = _userRepo.Get(user.Id);
        //    if (E == null)
        //        return NotFound();
        //    _userRepo.update(user.Id, user);
        //    return Ok();


        //}

    }
}
