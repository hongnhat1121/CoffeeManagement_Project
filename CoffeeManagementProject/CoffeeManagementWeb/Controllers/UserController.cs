using CoffeeManagement.BLL;
using CoffeeManagement.Common.Rsp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeManagement.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserSvc userSvc;
        public UserController()
        {
            userSvc = new UserSvc();
        }
        [HttpGet("get-all")]
        public IActionResult getUsersAll()
        {
            var res = new SingleRsp();
            res.Data = userSvc.All;
            return Ok(res);
        }
    }
}
