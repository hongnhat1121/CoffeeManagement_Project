using CoffeeManagement.BLL;
using CoffeeManagement.Common.Req;
using CoffeeManagement.Common.Rsp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        //Thêm cái get by id hay get by username nhờ???? , với delete user by id

        [HttpGet("get-all")]
        public IActionResult GetUsersAll()
        {
            var res = new SingleRsp();
            res.Data = userSvc.All;
            return Ok(res);
        }

        [HttpPost("create-user")]
        public IActionResult CreateUser([FromBody] UserReq userReq)
        {
            var res = new SingleRsp();
            res = userSvc.CreateUser(userReq);
            return Ok(res);
        }

        [HttpPut("update-user")]
        public IActionResult UpdateUser([FromBody] UpdateUserReq updateUserReq)
        {
            var res = new SingleRsp();
            res = userSvc.UpdateUser(updateUserReq);
            return Ok(res);
        }
    }
}
