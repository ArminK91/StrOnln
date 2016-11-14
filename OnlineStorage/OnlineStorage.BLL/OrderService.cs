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
using System.Net.Mail;
using System.Net.Mime;
using Onlinestorage.DALbBbbBb;

namespace OnlineStorage.BLL
{
    public class OrderService : IOrderService
    {
        private ApplicationDbContext _context;

        public OrderService(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Buy(OrderModel orderModel)
        {
            if (orderModel.Products.Count == 0)
                throw new ArgumentException("Number of products cannot be null!");

            //var newOrder = new OrderModel()
            //{
            //    DateOfOrder = orderModel.DateOfOrder,
            //    DateOfApproving = orderModel.DateOfApproving,
            //    Approved = orderModel.Approved,
            //    Quantity = orderModel.Quantity,
            //    Products = orderModel.Products,
            //    User = orderModel.User

            //};

            var newOrder = new Order()
            {
                DateOfApproving = orderModel.DateOfApproving,
                DateOfOrder = orderModel.DateOfOrder,
                Approved = orderModel.Approved,
                Quantity =  orderModel.Quantity,
                Products = _context.Products
                                    .Where(x => x.ID.Equals(orderModel.Products.Select(y => y.ID))).ToList(),
                User = _context.Users
                                .Where(x => x.Id.Equals(orderModel.User.Id)).FirstOrDefault()

            };

            _context.Orders.Add(newOrder);
            _context.SaveChanges();
            return true;

        }

        public ProductModel GetProductModel()
        {
            byte[] slika = new byte[32];
            return new ProductModel
            {
                Name = "",
                Activ = true,
                Details = "",
                Price = (double)0,
                Image = slika     
            };
        }
        private void SendMail(string emailAdress)
        {
            SmtpClient mailClient = new SmtpClient();

            MailMessage message = new MailMessage();

            message.From = new MailAddress("prodaja@email.com", "From Online Storage");
            message.To.Add(new MailAddress(emailAdress, "To Name"));

            message.Subject = "You recive mail for new order!";

            string text = "Text body";
            string html = @"<p> html body</p>";

            message.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(text, null, MediaTypeNames.Text.Plain));
            message.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(html, null, MediaTypeNames.Text.Html));

            mailClient.Send(message);
        }

        public ICollection<OrderModel> GetAllOrders()
        { 
            return
                 _context.Orders.
                    ToList().
                        Select(x => x.MapToOrderModel()).
                            ToList();
        }
    }
}
