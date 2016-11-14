using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStorage.DomainModel
{
    public class ApplicationUser : IdentityUser
    {
        public string FirsName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Gender { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

    }
}
