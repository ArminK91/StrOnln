using Onlinestorage.DAL;
using OnlineStorage.BLL;
using OnlineStorage.BLL.Interfaces;
using OnlineStorage.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OnlineStorage.WebAPI.Controllers
{
   // [Authorize]
    public class ProductsController : ApiController
    {
        private IProductService _productService;


        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        //GET: api/Products

        [HttpGet]
        [ActionName("GetProducts")]
     //   [Authorize(Roles = "Customer")]
        public IHttpActionResult Get()
        {
            var products = _productService.GetAllProducts();
            return Ok<ICollection<ProductModel>>(products);
        }

        //GET: api/Products/5

        [HttpGet]
        [ActionName("GetProduct")]
   //     [Authorize(Roles = "Customer")]
        public IHttpActionResult Get(string id)
        {
            var product = _productService.GetProductById(id);

            if (product == null)
                return NotFound();
            return Ok(product);
        }

        [HttpGet]
        [ActionName("GetProductModel")]
      //  [Authorize(Roles = "Administrator")]
        public IHttpActionResult GetProductModel()
        {
            var productModel = _productService.GetProductModel();

            return Ok<ProductModel>(productModel);
        }

        //POST: api/Products

        [HttpPost]
        [ActionName("Create")]
    //    [Authorize(Roles = "Administrator")]
        public IHttpActionResult Post([FromBody]ProductModel productModel)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _productService.SaveProduct(productModel);

            return Ok<ProductModel>(productModel);
        }


        [HttpGet]
        [ActionName("Delete")]
   //     [Authorize(Roles = "Administrator")]
        public IHttpActionResult Delete(string id)
        {
            if (id == null)
                return BadRequest();

            var itemDeleted = _productService.DeleteProduct(id);

            if (!itemDeleted)
                return NotFound();
            return Ok();
        }
    }
}
