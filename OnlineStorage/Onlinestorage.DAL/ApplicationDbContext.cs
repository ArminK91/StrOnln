using Microsoft.AspNet.Identity.EntityFramework;
using OnlineStorage.DomainModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onlinestorage.DALbBbbBb
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext() : base("Online Storage Database")
        {

        }
       // public virtual DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Order> Orders { get; set; }

        //public virtual DbSet<Administrator> Administrators { get; set; }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
         
    }
}
