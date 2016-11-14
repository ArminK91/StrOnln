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
    public class OrdersController : ApiController
    {
        private IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        //GET: api/Orders
        [HttpGet]
        [ActionName("Get")]
    //    [Authorize(Roles = "Administrator")]
        public IHttpActionResult Get()
        {
            var orders = _orderService.GetAllOrders();
            return Ok<ICollection<OrderModel>>(orders);
        }

        //POST: api/Orders

        [HttpPost]
        [ActionName("Create")]
    //    [Authorize(Roles = "Customer")]
        public IHttpActionResult Post([FromBody]OrderModel orderModel)
        {
            if (orderModel == null)
                return BadRequest("Invalid Data Passed!!");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var order = _orderService.Buy(orderModel);
            return Ok(order);
        }
    }
}
