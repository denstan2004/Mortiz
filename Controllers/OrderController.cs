using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mortiz.DAL.Interfaces;
using Mortiz.DAL.Repositories;
using Mortiz.Domain.Entity;
using Mortiz.Domain.ViewModel;
using System.Security.Claims;

namespace Mortiz.Controllers
{
    [Route("Order")]
    public class OrderController : Controller
    {
        private readonly IBaseRepository<Clothes> _clothesRepository;
        private readonly UserRepository _userRepository;
        private readonly OrderRepository orderRepository;

        public OrderController(IBaseRepository<Clothes> clothesRepository, UserRepository useRepository, OrderRepository orderRepository)
        {
            _clothesRepository = clothesRepository;
            _userRepository = useRepository;
            this.orderRepository = orderRepository;
        }

      //  [HttpPost("/singleOrder/{Clotheid}")]
       // public void SingleOrder([FromBody] OrderListViewModel orderListViewModel, int Clotheid)
      //  {
      //      var user = HttpContext.User;
      //      var userName = user.FindFirstValue(ClaimsIdentity.DefaultNameClaimType);
     //       var User = _userRepository.GetByName(userName);
     //       orderRepository.CreateSingleOrder(orderListViewModel, User.Id, Clotheid);
     //   }
        [HttpPost("singleOrder")]
        [Authorize]
        public void SingleOrder([FromBody] OrderActionData data)

        {
            var user = HttpContext.User;
            var userName = user.FindFirstValue(ClaimsIdentity.DefaultNameClaimType);
            var User = _userRepository.GetByName(userName);
            orderRepository.CreateSingleOrder(data.OrderListViewModel, User.Id, data.Clotheid);
        }

        [HttpPost("OrderList")]
        [Authorize]
        public void createOrders([FromBody] OrderActionData data)
        {
            Console.WriteLine(data.ClothesList);
            var user = HttpContext.User;
            var userName = user.FindFirstValue(ClaimsIdentity.DefaultNameClaimType);
            User User = _userRepository.GetByName(userName);
            orderRepository.CreateOrderList(data.ClothesList, data.OrderListViewModel, User.Id);
            if (User.Basket != null) { User.Basket.Clear(); }
        }

    }
}
