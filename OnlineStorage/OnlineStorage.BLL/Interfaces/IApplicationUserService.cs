using OnlineStorage.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStorage.BLL.Interfaces
{
    public interface IApplicationUserService
    {
        List<ApplicationUserModel> GetAllUsers();
        ApplicationUserModel GetUser(string id);
    }
}
