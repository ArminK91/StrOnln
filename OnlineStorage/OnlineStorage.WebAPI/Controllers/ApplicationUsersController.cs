using Onlinestorage.DAL;
using OnlineStorage.BLL;
using OnlineStorage.BLL.Interfaces;
using OnlineStorage.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace OnlineStorage.WebAPI.Controllers
{
  //  [Authorize]
    public class ApplicationUsersController : ApiController
    {

        private IApplicationUserService _applicationUserSerivce;

        public ApplicationUsersController(IApplicationUserService applicationUserService)
        {
            _applicationUserSerivce = applicationUserService;
        }
   

       
        //GET: api/ApplicationUsers
        [HttpGet]
        [ActionName("GetUsers")]
      //  [Authorize(Roles = "Administrator")]
        public IHttpActionResult GetAllUsers()
        {
            var users = _applicationUserSerivce.GetAllUsers();
            return Ok<ICollection<ApplicationUserModel>>(users);
        }

        //GET: api/ApplicationUsers/GetUser

        [HttpGet]
        [ActionName("GetUser")]
    //    [Authorize(Roles = "Administrator")]
        public IHttpActionResult GetUser(string id)
        {
            var user = _applicationUserSerivce.GetUser(id);
            return Ok<ApplicationUserModel>(user);
        }

    }
}