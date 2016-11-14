using OnlineStorage.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStorage.DTO
{
    public class OrderModel
    {
        public string Id { get; set; }
        public DateTime DateOfOrder { get; set; }
        public int Quantity { get; set; }
        public bool Approved { get; set; }
        public DateTime? DateOfApproving { get; set; }

        public virtual ICollection<ProductModel> Products { get; set; }

        public virtual ApplicationUserModel User { get; set; }
    }
}
