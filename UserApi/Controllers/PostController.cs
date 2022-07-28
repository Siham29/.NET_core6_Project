using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using UserApi.Models;
using UserApi.Repo;

namespace UserApi.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {

        private readonly IPostRepo _postRepo;

        public PostController(IPostRepo postRepo)
        {
            _postRepo = postRepo;
        }

        [HttpGet]
        [ActionFilter("Admin")]
        public ActionResult<List<Post>> GetAll()
        {
            return _postRepo.GetAll();


        }
        [HttpGet("{id}")]
        public ActionResult<Post> Get(int id)
        {

            var post = _postRepo.Get(id);
            if (post == null)

                return NotFound();
            return post;

        }
        [HttpDelete("{id}")]

        public ActionResult Deletet(int id)
        {

            var user1 = _postRepo.Get(id);
            if (user1 == null)

                return NotFound();
            _postRepo.Delete(id);
            return Ok();

        }
        [HttpPost]
        public ActionResult Create([FromBody] Post post)
        {
           
            try
            {
                _postRepo.Add(post);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }


        }
        [HttpPut]
        public ActionResult Update(Post post)
        {
           
            _postRepo.Update(post);
            return Ok();


        }

    
}
}
