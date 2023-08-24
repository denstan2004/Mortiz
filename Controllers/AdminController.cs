using Microsoft.AspNetCore.Mvc;
using Mortiz.DAL.Interfaces;
using Mortiz.DAL.Repositories;
using Mortiz.Domain.Entity;

namespace Mortiz.Controllers
{
    public class AdminController : Controller
    {

        private readonly ClothesRepository _clothesRepository;
        private readonly OrderRepository _orderRepository;

        public AdminController(ClothesRepository clothesRepository, OrderRepository orderRepository)
        {
            _clothesRepository = clothesRepository;
            _orderRepository = orderRepository;
           
        }
        [HttpPost]
        [Route("Create")]
        public IActionResult CreateClothes([FromBody] Clothes clothes)
        {
            _clothesRepository.Create(clothes);
            return Ok(200);

        }
        [HttpPost("Delete/{id}")]
        public void DeleteClothes(int id)
        {
            _clothesRepository.Delete(id);
        }


        [HttpPost ("checkClothe/{id}")]
        public void CheckOrder(int id) 
        {
            _orderRepository.CheckOrder(id);         
        }
        [HttpPatch ("update")]
        public Clothes Update (int id, Clothes updatedItem)
        {

        }

    }// контроллери під оновлення речі
}
