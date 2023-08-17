using Microsoft.EntityFrameworkCore;
using Mortiz.DAL.Interfaces;
using Mortiz.Domain.Entity;

namespace Mortiz.DAL.Repositories
{
    public class ClothesRepository : IClothesRepository

    {
        private readonly ApplicationDbContext _context;

        public ClothesRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Create(Clothes entity)
        {
         
                _context.Clothes.Add(entity);
                _context.SaveChanges();
                
         
        }
        public void Update(Clothes entity, int id) 
        {
            _context.Remove(id);
            _context.Add(entity);
            _context.SaveChanges();
        }

        public bool Delete(int id)
        {
            var itemToDelete = _context.Clothes.FirstOrDefault(x => x.Id == id);

            if (itemToDelete != null)
            {
                _context.Clothes.Remove(itemToDelete);
                _context.SaveChanges();
                return true; 
            }

            return false; 
        }

        public Clothes Get(int id)
        {
            return _context.Clothes.FirstOrDefault(x => x.Id == id);
        }

        public Task<List<Clothes>> SelectAll()
        {
            return _context.Clothes.ToListAsync();
        }

      
    }
}
