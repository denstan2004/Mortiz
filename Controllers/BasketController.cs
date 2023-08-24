using Microsoft.AspNetCore.Mvc;
using Mortiz.DAL.Interfaces;
using Mortiz.DAL.Repositories;
using Mortiz.Domain.Entity;
using Mortiz.Domain.ViewModel;
using System.Net;
using System.Security.Claims;

namespace Mortiz.Controllers
{
    public class BasketController : Controller
    {
        private readonly OrderRepository orderRepository;
        private readonly ClothesRepository clothesRepository;
        private readonly UserRepository userRepository;

        public BasketController(OrderRepository orderRepository, ClothesRepository clothesRepository, UserRepository userRepository)
        {
            this.orderRepository = orderRepository;
            this.clothesRepository = clothesRepository;
            this.userRepository = userRepository;
        }

        [HttpGet("/getAll/Clothes")]
        public Task<List<Clothes>> GetAllClothesFromUser()
       {
            var user = HttpContext.User;
            var userName = user.FindFirstValue(ClaimsIdentity.DefaultNameClaimType);
            User User = userRepository.GetByName(userName);
            List<Clothes> result = clothesRepository.SelectAllFromUser(User.Basket);
            return Task.FromResult(result);
        }


     
       
    }
}
