using Microsoft.EntityFrameworkCore;
using Mortiz.DAL.Interfaces;
using Mortiz.Domain.Entity;
using Mortiz.Domain.ViewModel;

namespace Mortiz.DAL.Repositories
{
    public class OrderRepository 
    {
        private readonly OrderRepository _orderRepository;
        private readonly ApplicationDbContext _context;

        public OrderRepository(ApplicationDbContext context)
        {
          
            _context = context;
        }
        public void CreateOrderList(List<int> orderList, OrderListViewModel orderListViewModel, int Userid)
        {
            for (int i = 0; i < orderList.Count; i++)
            {
                Order order = new Order();
                order.Address = orderListViewModel.Address;
                order.DateCreated = DateTime.UtcNow; // Перетворення на UTC
                order.Telephone = orderListViewModel.Telephone;
                order.Checked = false;
                order.ClothId = orderList[i];
                order.UserId = Userid;
                order.LastName = orderListViewModel.LastName;
                order.MiddleName = orderListViewModel.MiddleName;
                order.FirstName = orderListViewModel.FirstName;
                _context.Add(order);
            }
            _context.SaveChanges();
        }

        public void CreateSingleOrder(OrderListViewModel orderModel, int userId, int clotheId)
        {
            Order order = new Order();
            order.UserId = userId;
            order.Checked = false;
            order.ClothId = clotheId;
            order.DateCreated = DateTime.UtcNow; // Перетворення на UTC
            order.Address = orderModel.Address;
            order.Telephone = orderModel.Telephone;
            order.LastName = orderModel.LastName;
            order.MiddleName = orderModel.MiddleName;
            order.FirstName = orderModel.FirstName;
            _context.Orders.Add(order);
            _context.SaveChanges();
        }

        public void CheckOrder(Order order)
        {
            _context.Remove(((int)order.Id));
            order.Checked = true;
           _context.Add(order);
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

        public void CheckOrder(int id)
        {
            Order order = _context.Orders.FirstOrDefault(x => x.Id == id);
            order.Checked= true;
            _context.Update(order);
            _context.SaveChanges();
        }


        public Order Get(int id)
        {
            return _context.Orders.FirstOrDefault(x => x.Id == id);
            
        }

        public Task<List<Order>> SelectAll()
        {
            return _context.Orders.ToListAsync();


        }
        public Task<List<Order>> SelectAllForUser(int userId)
        {
            return _context.Orders
                .Where(order => order.UserId == userId)
                .ToListAsync();
        }

        public void Create(Order entity)
        {
            throw new NotImplementedException();
        }
    }
}
