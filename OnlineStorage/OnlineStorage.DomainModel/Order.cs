using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStorage.DomainModel
{
    public class Order
    {
        public string ID { get; set; }
        public DateTime DateOfOrder { get; set; }
        public int Quantity { get; set; }
        public bool Approved { get; set; }
        public DateTime? DateOfApproving { get; set; }

        public virtual ICollection<Product> Products { get; set; }

     
        public virtual ApplicationUser User { get; set; }

        public Order()
        {
            ID = Guid.NewGuid().ToString();
        }
    }
}
