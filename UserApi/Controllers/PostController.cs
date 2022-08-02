using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using UserApi.Models;
using UserApi.Repo;
using UserApi.ViewModel;

namespace UserApi.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {

        private readonly IPostRepo _postRepo;
        private readonly IMapper _mapper;

        public PostController(IPostRepo postRepo,IMapper mapper)
        {
            _postRepo = postRepo;
            _mapper = mapper;   
        }

        [HttpGet]
        //[ActionFilter("Admin")]
        public async Task<ActionResult<List<PostViewModel>>> GetAll()
        {

            return _mapper.Map<List<PostViewModel>>( await _postRepo.GetAll<PostViewModel>()) ;


        }
        [HttpGet("{id}")]
        public async Task<ActionResult<PostViewModel>> Get(int id)
        {

            var post =  await _postRepo.Get<PostViewModel>(id);
            if (post == null)

                return NotFound();
            return post ;

        }
        [HttpDelete("{id}")]

        public async Task<ActionResult> Deletet(int id)
        {

            var user1 = await _postRepo.Get<PostViewModel>(id);
            if (user1 == null)

                return NotFound();
           await _postRepo.Delete(id);
            return Ok();

        }
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] PostViewModel post)
        {
           
            try
            {
                var _post = _mapper.Map<Post>(post);
             
                await _postRepo.Add( _post);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }


        }
        [HttpPut]
        public async Task <ActionResult> Update(PostViewModel post)
        {
           
           await _postRepo.Update(_mapper.Map<Post>(post));
            return Ok();


        }

    
}
}
