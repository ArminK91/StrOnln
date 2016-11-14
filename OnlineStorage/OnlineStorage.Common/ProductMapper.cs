using OnlineStorage.DomainModel;
using OnlineStorage.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStorage.Common
{
    public static class ProductMapper
    {

        public static ProductModel MapToProductModel(this Product product)
        {
            if (product == null)
                return null;

            return new ProductModel
            {
                ID = product.ID,
                Name = product.Name,
                Price = product.Price,
                Image = product.Image,
                Orders = product.Orders.Select(v => v.MapToOrderModel()).ToList(),
                Details = product.Details,
                Activ = product.Activ
            };
        }
    }
}
