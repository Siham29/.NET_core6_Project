using UserApi.Models;

namespace UserApi.Repo
{
    public interface IGenercicRepo<T> where T:class,IBaseModel
    {

        public List<T> ? GetAll();
        public T ? Get(int id);
        public void Delete(int id);
        public T  Add(T obj);

        public T Update(T obj);

    }
    public class GenercicRepo<T>: IGenercicRepo<T>  where T : class ,IBaseModel
    {
        public UserContext _context;

        public GenercicRepo(UserContext context)
        {

            _context = context;


        }


        public List<T> ? GetAll()
        {


            return _context.Set<T>().ToList();
        }
        public T? Get(int id)
        {

              return _context.Set<T>().Find(id);
        }


        public void Delete(int id)
        {


            var _temp = Get(id);
            
                _context.Set<T>().Remove
                    (_temp);
                _context.SaveChanges();



        }
        public T Add(T obj)
        {

             _context.Set<T>().Add(obj);
            _context.SaveChanges();
            return obj;

        }


        public T Update(T obj)
        {
                _context.Set<T>().Update(obj);
                _context.SaveChanges();
            return obj;

            }


        }
    }

   

