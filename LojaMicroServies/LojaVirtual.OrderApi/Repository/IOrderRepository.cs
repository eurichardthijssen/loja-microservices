
using LojaVirtual.OrderAPI.Model;

namespace LojaVirtual.OrderApi.Repository
{
    public interface IOrderRepository
    {

        Task<bool> AddOrder(OrderHeader header);
        Task UpdateOrderPaymentStatus(long orderHeaderId, bool paid);

    }
}
