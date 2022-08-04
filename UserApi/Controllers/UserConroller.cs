using Microsoft.AspNetCore.Mvc;
using UserApi.Repo;
using UserApi.Models;
using AutoMapper;
using UserApi.ViewModel;
using Microsoft.AspNetCore.Authorization;
using JWTAuthentication.NET6._0.Auth;

namespace UserApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserConroller : ControllerBase

    {
        private readonly IUserRepo _userRepo;
        private readonly IMapper _mapper;

        public UserConroller(IUserRepo userRepo, IMapper mapper)
        {
            _userRepo = userRepo;
            _mapper = mapper;
        }

        [HttpGet]
        //[ActionFilter("Admin")]
        public async Task<ActionResult<List<UserViewModel>>> GetAll()
        {
                  return _mapper.Map<List<UserViewModel>>(await _userRepo.GetAll<UserViewModel>());



        }
        [HttpGet("{id}")]
        public async Task<ActionResult<UserViewModel> >Get(int id)
        {

            var user =await _userRepo.Get<UserViewModel>(id);
            if (user == null)

                return NotFound();
            return user;

        }
        [HttpDelete("{id}")]

        public async Task< ActionResult> Deletet(int id)
        {

            var user1 = await _userRepo.Get<UserViewModel>(id);
            if (user1 == null)

                return NotFound();
            await _userRepo.Delete(id);
            return Ok();

        }
        [HttpPost]
        public async Task <ActionResult> Create([FromBody] UserViewModel user)
        {

            try
            {
                var _user = _mapper.Map<User>(user);
                
                await _userRepo.Add( _user);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }



        }
        [HttpPut]
        public async Task <ActionResult >Update(UserViewModel user)
        {
           
            _userRepo.Update(_mapper.Map<User>(user));
            return Ok();


            }

        }
}
