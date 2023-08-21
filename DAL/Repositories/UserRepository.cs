using Microsoft.EntityFrameworkCore;
using Mortiz.DAL.Interfaces;
using Mortiz.Domain.Entity;

namespace Mortiz.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }
      
        void IBaseRepository<User>.Create(User entity)
        {
            _context.User.Add(entity);
            _context.SaveChanges();
           
        }

        bool IBaseRepository<User>.Delete(int id)
        {
            var itemToDelete = _context.User.FirstOrDefault(x => x.Id == id);

            if (itemToDelete != null)
            {
                _context.User.Remove(itemToDelete);
                _context.SaveChanges();
                return true;
            }

            return false;
        }

        User IBaseRepository<User>.Get(int id)
        {
            return _context.User.FirstOrDefault(x => x.Id == id);
        }

        Task<List<User>> IBaseRepository<User>.SelectAll()
        {
            return _context.User.ToListAsync();
        }

     public   User GetByName(String name)
        {
            return _context.User.FirstOrDefault(x => x.Name == name);
        }


    }
}
