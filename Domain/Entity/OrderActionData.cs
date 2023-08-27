using Mortiz.Domain.ViewModel;

namespace Mortiz.Domain.Entity
{
    public class OrderActionData
    {
        public OrderListViewModel OrderListViewModel { get; set; }
        public int Clotheid { get; set; }
        public List<int> ClothesList { get; set; }
    }
}
