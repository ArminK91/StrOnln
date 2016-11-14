namespace Onlinestorage.DAL.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using OnlineStorage.DomainModel;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Onlinestorage.DAL.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Onlinestorage.DAL.ApplicationDbContext context)
        {
            base.Seed(context);

            #region UsersAndRoles
            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);

            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);

            const string customer = "Customer";
            if (!context.Roles.Any(x => x.Name == customer))
                roleManager.Create(new IdentityRole { Name = customer });

            const string administrator = "Administrator";
            if (!context.Roles.Any(c => c.Name == administrator))
                roleManager.Create(new IdentityRole { Name = administrator });

            //we will add few customers and administarotr

            var customerArmin = new ApplicationUser
            {
                FirsName = "Armin",
                LastName = "Keco",
                Gender = "Male",
                Email = "armin.keco@hotmail.com",
                UserName = "akeco1"
            };
            if (!context.Users.Any(x => x.UserName == customerArmin.UserName))
            {
                userManager.Create(customerArmin, "Pass4User!$");
                userManager.AddToRole(customerArmin.Id, administrator);
            }

            var customerEdis = new ApplicationUser
            {
                FirsName = "Edis",
                LastName = "Hapic",
                Gender = "Male",
                Email = "edis.hapic@hotmail.com",
                UserName = "edis1"
            };
            if (!context.Users.Any(x => x.UserName == customerEdis.UserName))
            {
                userManager.Create(customerEdis, "Pass4User!$");
                userManager.AddToRole(customerEdis.Id, customer);
            }
            #endregion

            #region Products

            
            
                var productCar = new Product
                {
                    Name = "Audi",
                    Price = 30000,
                    Activ = true,
                    Details = "This car is awesome. I strongly recommand you to buy it!!",
                    Image = System.IO.File.ReadAllBytes(@"C:\\Temp1\Car1.png")

                };

                context.Products.AddOrUpdate(productCar);

                var productPlain = new Product
                {
                    Name = "Boing",
                    Price = 3000000000,
                    Activ = true,
                    Details = "This plane is awesome. I strongly recommand you to buy it!!",
                    Image = System.IO.File.ReadAllBytes(@"C:\\Temp1\Plane.jpg")
                };

                context.Products.AddOrUpdate(productPlain);

                var productComputer = new Product
                {
                    Name = "Master",
                    Price = 3000,
                    Activ = true,
                    Details = "This computer is awesome. I strongly recommand you to buy it!!",
                    Image = System.IO.File.ReadAllBytes(@"C:\\Temp1\Computer.jpg")
                };

                context.Products.AddOrUpdate(productComputer);

                var productApple = new Product
                {
                    Name = "Notebook",
                    Price = 3000,
                    Activ = true,
                    Details = "This notebook is awesome. I strongly recommand you to buy it!!",
                    Image = System.IO.File.ReadAllBytes(@"C:\\Temp1\Apple.jpg")
                };

                context.Products.AddOrUpdate(productApple);

            
            #endregion
        }
    }
}
