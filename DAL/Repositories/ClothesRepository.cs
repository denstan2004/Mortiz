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

        public bool create(Clothes entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Clothes Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Clothes>> SelectAll()
        {
            return _context.Clothes.ToListAsync();
        }

      
    }
}
