using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStorage.DTO
{
    public class ProductModel
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public byte[] Image { get; set; }     
        public string Details { get; set; }
        public bool Activ { get; set; }

        public virtual ICollection<OrderModel> Orders { get; set; }
        public ProductModel Product { get; set; }
    }
}
