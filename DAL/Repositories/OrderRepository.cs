using Microsoft.EntityFrameworkCore;
using Mortiz.DAL.Interfaces;
using Mortiz.Domain.Entity;
using Mortiz.Domain.ViewModel;

namespace Mortiz.DAL.Repositories
{
    public class OrderRepository 
    {
        private readonly IBaseRepository<Order> _orderRepository;
        private readonly ApplicationDbContext _context;

        public OrderRepository(ApplicationDbContext context)
        {
          
            _context = context;
        }
        public void CreateOrderList(List<int> orderList, OrderListViewModel orderListViewModel)
        {
            Order order = new Order();
            for (int i = 0; i <orderList.Capacity; i++)
            {
                order.Address = orderListViewModel.Address;
                order.DateCreated = DateTime.Now;
                order.Telephone = orderListViewModel.Telephone;
                order.Checked = false;
                order.ClothId = orderList[i];
                order.LastName= orderListViewModel.LastName;
                order.MiddleName = orderListViewModel.MiddleName;
                order.FirstName = orderListViewModel.FirstName;
                _context.Add(order);
            }
            _context.SaveChanges();

        }
        public void CheckOrder(Order order)
        {
            _context.Remove(((int)order.Id));
            order.Checked = true;
           _context.Add(order);
            _context.SaveChanges();

        }
        public void Create(Order order, int userId)
        {
            order.UserId=userId;
            order.Checked = false;
            order.DateCreated = DateTime.Now;
            _context.Orders.Add(order);
            _context.SaveChanges();
        }

        public bool Delete(int id)
        {

            var itemToDelete = _context.Orders.FirstOrDefault(x => x.Id == id);

            if (itemToDelete != null)
            {
                _context.Orders.Remove(itemToDelete);
                _context.SaveChanges();
                return true;
            }

            return false;
        }

        public Order Get(int id)
        {
            return _context.Orders.FirstOrDefault(x => x.Id == id);
            
        }

        public Task<List<Order>> SelectAll()
        {
            return _context.Orders.ToListAsync();

        }

        public void Create(Order entity)
        {
            throw new NotImplementedException();
        }
    }
}
