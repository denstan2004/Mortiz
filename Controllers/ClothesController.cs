using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mortiz.DAL;
using Mortiz.DAL.Interfaces;
using Mortiz.DAL.Repositories;
using Mortiz.Domain.Entity;
using Mortiz.Domain.ViewModel;
using System.Security.Claims;

namespace Mortiz.Controllers
{
    [Route("Clothes")]
    public class ClothesController : Controller
    {
        private readonly ClothesRepository _clothesRepository;
        private readonly UserRepository _useRepository;
        private readonly OrderRepository orderRepository;

        public ClothesController(ClothesRepository clothesRepository, UserRepository useRepository, OrderRepository orderRepository)
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

        [HttpPost("addToFavourite/{id}")]
        [Authorize]
        public void addToFavourite(int id)
        {

            var user = HttpContext.User;
            var userName = user.FindFirstValue(ClaimsIdentity.DefaultNameClaimType);
            var User = _useRepository.GetByName(userName);
            User.Basket.Add(id);
        }
        [HttpGet("get/all/categories")]
        public List<String> GetAllCategories()
            {
              return _clothesRepository.GetAllCategories();

            }
        [HttpGet("get/all/from/category")]
        public List<Clothes> GetAllFromCategories(String category)
        {
            return _clothesRepository.FindALLFromCategory(category) ;

        }

        [HttpGet("auth")]
        public IActionResult authcheck()
        {
           if(HttpContext.User.Identity.IsAuthenticated)
            { return Ok(200); }
            else { return BadRequest(300); }
        }


    }
}