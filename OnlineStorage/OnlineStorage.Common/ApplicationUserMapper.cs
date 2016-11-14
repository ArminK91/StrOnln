using OnlineStorage.DomainModel;
using OnlineStorage.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStorage.Common
{
    public static class ApplicationUserMapper
    {
        public static ApplicationUserModel MapToApplicationUserModel(this ApplicationUser user)
        {
            if (user == null)
                return null;
            return new ApplicationUserModel
            {
                Id = user.Id,
                FirsName = user.FirsName,
                LastName = user.LastName

            };
        }
    }
}
