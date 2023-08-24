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
            Clothes item = _context.Clothes.FirstOrDefault().;
            _context.SaveChanges();
        } //змінити на оновлення

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

        public List<Clothes> SelectAllFromUser(List<int> clothesId)
        {
            List<Clothes> clothes = new List<Clothes>();
           for(int i=0; i<clothesId.Count; i++)
            {
                clothes.Add(Get(clothesId[i]));
            }
            return clothes; ;

        }
        public List<Clothes> FindALLFromCategory (String  category)
        {
            List<Clothes> clothes = _context.Clothes.Where(x => x.Type == category).ToList();
            return clothes;
        }
        public List<String> GetAllCategories()
        {
            List<String> category= new List<string> ();
            List<Clothes> clothes = _context.Clothes.ToList();
            for(int i=0; i<clothes.Count; i++)
            {
                if(category== null ) { category.Add(clothes[i].Type); }
                else if (category.Contains(clothes[i].Type)==false) { category.Add(clothes[i].Type); }
            }
            return category;
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
