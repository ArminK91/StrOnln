using OnlineStorage.DomainModel;
using OnlineStorage.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStorage.Common
{
    public static class OrderMapper
    {
        public static OrderModel MapToOrderModel(this Order order)
        {
            if (order == null)
                return null;

            return new OrderModel
            {
                Id = order.ID,
                DateOfOrder = order.DateOfOrder,
                Products = order.Products.Select(x => x.MapToProductModel()).ToList(),
                DateOfApproving = order.DateOfApproving,
                Quantity = order.Quantity,
                User = order.User.MapToApplicationUserModel(),
                Approved = order.Approved
           };
        }

        //public static Order MapToOrder(this OrderModel order)
        //{
        //    if (order == null)
        //        return null;

        //    return new Order
        //    {
        //        Approved = order.Approved,
        //        DateOfApproving = order.DateOfApproving,
        //        DateOfOrder = order.DateOfOrder,
        //        Products = 

        //    };
        //}
    }
}
