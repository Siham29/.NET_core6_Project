using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using UserApi.Models;

namespace UserApi.Repo
{
    public interface IGenercicRepo<T> where T:class,IBaseModel
    {

        public Task<List<TVM>>? GetAll<TVM>();
        public Task<TVM>? Get<TVM>(int id) where TVM : class, IBaseModel;
        public Task Delete (int id);
        public Task<T> Add(T obj);

        public Task<T>Update(T obj);

    }
    public class GenercicRepo<T>: IGenercicRepo<T>  where T : class ,IBaseModel
    {
        public UserContext _context;
        public IMapper _mapper;
        public GenercicRepo(UserContext context, IMapper mapper)
        {

            _context = context;
            _mapper = mapper;


        }


        public async Task <List<TVM>>? GetAll<TVM>() 
        {
            return _context.Set<T>().ProjectTo<TVM>(_mapper.ConfigurationProvider).ToList();
        }
        public async Task <TVM> ? Get <TVM>(int id) where TVM : class, IBaseModel
        {

              return   _context.Set<T>().ProjectTo<TVM>(_mapper.ConfigurationProvider).FirstOrDefault(c => c.Id == id);
        }


        public async Task Delete (int id)
        {
            var temp = await _context.Set<T>().FirstOrDefaultAsync(c => c.Id == id);
            _context.Set<T>().Remove( temp);
            await _context.SaveChangesAsync();


        }
        public async Task<T> Add(T obj)
        {

             await _context.Set<T>().AddAsync(obj);
             await _context.SaveChangesAsync();
            return obj;

        }


        public async Task<T> Update(T obj)
        {
                _context.Set<T>().Update(obj);
               await _context.SaveChangesAsync();
            return obj;

            }


        }
    }

   

