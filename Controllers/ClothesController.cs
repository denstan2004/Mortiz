using Microsoft.AspNetCore.Mvc;
using Mortiz.DAL.Interfaces;
using Mortiz.Domain.Entity;

namespace Mortiz.Controllers
{
    [Route("api")]
    public class ClothesController : Controller
    {
        private readonly IBaseRepository<Clothes> _clothesRepository;

        public ClothesController(IBaseRepository<Clothes> clothesRepository)
        {
            _clothesRepository = clothesRepository;
        }

        [HttpGet("allClothes")]
        public async Task<IActionResult> AllClothes()
        {
            var result = await _clothesRepository.SelectAll();
            return Ok(result);
        }
        [HttpGet("Clothes/{id}")]
        public IActionResult GetOne(int id)
        {
            return Ok(_clothesRepository.Get(id));
        }


        //-------------------------------  admin panel below
        [HttpPost]
        [Route("Create")]
        public IActionResult CreateClothes([FromBody] Clothes clothes)
        {
            _clothesRepository.Create(clothes);
            return Ok(200);

        }
        [HttpPost("Delete/{id}")]
        public IActionResult DeleteClothes(int id)
        {
            _clothesRepository.Delete(id);
            return Ok();
        }

    }
}