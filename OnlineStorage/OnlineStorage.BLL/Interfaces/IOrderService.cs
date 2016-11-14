using OnlineStorage.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStorage.BLL.Interfaces
{
    public interface IOrderService
    {
        //signatures of methods

        bool Buy(OrderModel product);
        ICollection<OrderModel> GetAllOrders();
    }
}
