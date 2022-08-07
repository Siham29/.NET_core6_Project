using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserApi.Models;
using UserApi.Repo;
using UserApi.ViewModel;


namespace UserApi.Controllers
{
    [Authorize]
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


            return _mapper.Map<List<PostViewModel>>(await _postRepo.GetAll<PostViewModel>());


        }

        [HttpGet("page")]
        //[ActionFilter("Admin")]
        public async Task<ActionResult<List<Post>>> GetBySearch(int page, int size, String title)
        {


            return await _postRepo.Search(page, size, title) ;


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
           
       
                var _post = _mapper.Map<Post>(post);
                var userId = User.Claims?.SingleOrDefault(p => p.Type == "UserId")?.Value;
               _post.UserId= Convert.ToInt32(userId);
                await _postRepo.Add( _post, Convert.ToInt32(userId));
                return Ok();
            


        }
        [HttpPut]
        public async Task <ActionResult> Update(PostViewModel post)
        {
            var userId = User.Claims?.SingleOrDefault(p => p.Type == "UserId")?.Value;

            await _postRepo.Update(_mapper.Map<Post>(post), Convert.ToInt32(userId));
            return Ok();


        }

    
}
}
