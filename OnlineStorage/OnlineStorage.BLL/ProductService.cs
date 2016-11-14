using OnlineStorage.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineStorage.DTO;
using Onlinestorage.DAL;
using OnlineStorage.Common;
using OnlineStorage.DomainModel;
using Onlinestorage.DALbBbbBb;

namespace OnlineStorage.BLL
{
    public class ProductService : IProductService
    {

        private ApplicationDbContext _context;

        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }

        public ProductModel GetProductModel()
        {
            byte[] img = new byte[32];
            return new ProductModel
            {
                Product = new ProductModel
                { 
                    Name = "",
                    Activ = false,
                    Details = "",
                    Price = (double)0,
                    Image = img,
                },

            };
        }

        public bool DeleteProduct(string id)
        {
            var product = _context.Products.Where(x => x.ID == id).FirstOrDefault();

            if (product == null)
            {
                throw new ArgumentException("The Id is not valid!");
            }

            _context.Products.Remove(product);
            _context.SaveChanges();
            return true;
        }

        public ICollection<ProductModel> GetAllProducts()
        {
            return _context
                    .Products.ToList()
                        .Select(x => x.MapToProductModel()).ToList();
           
        }

        public ProductModel GetProductById(string id)
        {
            return
                _context.Products.Where(x => x.ID == id)
                            .FirstOrDefault().MapToProductModel();
        }

        public ProductModel SaveProduct(ProductModel productModel)
        {
            if (productModel == null)
                throw new ArgumentException("productModel", "ProductModel cannot be null!");

            ValidateProductModel(productModel);

            var newProduct = new Product()
            {
                Name = productModel.Name,
                Details = productModel.Details,
                Image = productModel.Image,
                Price = productModel.Price,
                Activ = productModel.Activ
            };

            _context.Products.Add(newProduct);
            _context.SaveChanges();

            return newProduct.MapToProductModel();
        }

        private void ValidateProductModel(ProductModel productModel)
        {
            if (productModel.Name == null || productModel.Name == String.Empty)
            {
                throw new ArgumentException();
            }
            else if(productModel.Details == null || productModel.Details == String.Empty)
            {
                throw new ArgumentException();
            }
            else if(productModel.Price <= 0 )
            {
                throw new ArgumentException();
            }
        }
    }
}
