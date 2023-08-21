using Microsoft.AspNetCore.Mvc;
using Mortiz.DAL;
using Mortiz.DAL.Interfaces;
using Mortiz.DAL.Repositories;
using Mortiz.Domain.Entity;
using Mortiz.Domain.ViewModel;
using System.Security.Claims;

namespace Mortiz.Controllers
{
    [Route("api")]
    public class ClothesController : Controller
    {
        private readonly IBaseRepository<Clothes> _clothesRepository;
        private readonly UserRepository _useRepository;
        private readonly OrderRepository orderRepository;

        public ClothesController(IBaseRepository<Clothes> clothesRepository,UserRepository useRepository, OrderRepository orderRepository)
        {
            _clothesRepository = clothesRepository;
            _useRepository = useRepository;
            this.orderRepository = orderRepository;
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


        public void addToFavourite(int id)
        {

            var user = HttpContext.User;
            var userName = user.FindFirstValue(ClaimsIdentity.DefaultNameClaimType);
            var User = _useRepository.GetByName(userName);
            User.Basket.Add(id);
        }

        public void SingleOrder(OrderListViewModel orderListViewModel, int Clotheid)
        {
            var user = HttpContext.User;
            var userName = user.FindFirstValue(ClaimsIdentity.DefaultNameClaimType);
            var User = _useRepository.GetByName(userName);
            orderRepository.CreateSingleOrder(orderListViewModel, User.Id, Clotheid);
            

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