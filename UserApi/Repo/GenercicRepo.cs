using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using UserApi.Models;

namespace UserApi.Repo
{
    public interface IGenercicRepo<T> where T:class,IBaseModel
    {

        public Task<List<T>>? GetAll();
        public Task<T>? Get(int id);
        public Task Delete (int id);
        public Task<T> Add(T obj);

        public Task<T>Update(T obj);

    }
    public class GenercicRepo<T>: IGenercicRepo<T>  where T : class ,IBaseModel
    {
        public UserContext _context;

        public GenercicRepo(UserContext context)
        {

            _context = context;


        }


        public async Task <List<T> >? GetAll()
        {


            return _context.Set<T>().ToList();
        }
        public async Task <T> ? Get(int id)
        {

              return   _context.Set<T>().Find(id);
        }


        public async Task Delete (int id)
        {
            var temp = _context.Set<T>().FirstOrDefaultAsync(c => c.Id == id);
            _context.Set<T>().Remove(await temp);
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

   

