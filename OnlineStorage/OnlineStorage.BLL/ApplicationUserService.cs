using Onlinestorage.DAL;
using Onlinestorage.DALbBbbBb;
using OnlineStorage.BLL.Interfaces;
using OnlineStorage.Common;
using OnlineStorage.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStorage.BLL
{
    public class ApplicationUserService : IApplicationUserService
    {
        private ApplicationDbContext _context;

        public ApplicationUserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<ApplicationUserModel> GetAllUsers()
        {
            return
                _context.Users.ToList()
                .Select(x => x.MapToApplicationUserModel()).ToList();
        } 

        public ApplicationUserModel GetUser(string id)
        {
            return
                _context.Users
                    .Where(x => x.Id == id)
                    .FirstOrDefault()
                        .MapToApplicationUserModel();
        }
    }
}
