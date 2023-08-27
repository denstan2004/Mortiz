using Domain.Enum;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mortiz.DAL.Interfaces;
using Mortiz.DAL.Repositories;
using Mortiz.Domain.Entity;
using Mortiz.Domain.ViewModel;

namespace Mortiz.Controllers
{
    [Route("Admin")]
    public class AdminController : Controller
    {

        private readonly ClothesRepository _clothesRepository;
        private readonly OrderRepository _orderRepository;

        public AdminController(ClothesRepository clothesRepository, OrderRepository orderRepository)
        {
            _clothesRepository = clothesRepository;
            _orderRepository = orderRepository;
           
        }
        [HttpPost("Create")]
        [Authorize(Roles = "admin")]
        public IActionResult CreateClothes([FromBody] Clothes clothes)
        {
            _clothesRepository.Create(clothes);
            return Ok(200);

        }
        [HttpPost("Delete/{id}")]
        [Authorize(Roles = "admin")]
        public void DeleteClothes(int id)
        {
            _clothesRepository.Delete(id);
        }


        [HttpPost ("checkClothe/{id}")]
        [Authorize(Roles = "admin")]
        public void CheckOrder(int id) 
        {
            _orderRepository.CheckOrder(id);         
        }
        [HttpPatch ("update")]
        [Authorize(Roles = "admin")]
        public void Update (int id, UpdateClotheModel updatedItem)
        {

            _clothesRepository.Update(updatedItem,id );
        }

    }// контроллери під оновлення речі
}
