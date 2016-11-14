
using OnlineStorage.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStorage.BLL.Interfaces
{
   public interface IProductService
    {
        //methods signatures for retriving, creating etc. products

        ProductModel SaveProduct(ProductModel product);

        ProductModel GetProductById(string id);

        ICollection<ProductModel> GetAllProducts();

        ProductModel GetProductModel();
        

        bool DeleteProduct(string id);
    }
}
