using CoffeeManagement.BLL;
using CoffeeManagement.Common.Req;
using CoffeeManagement.Common.Rsp;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeManagement.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly CategorySvc categorySvc;

        public CategoryController()
        {
            categorySvc = new CategorySvc();
        }

        [HttpPost("get-by-id")]
        public IActionResult getCategoryById([FromBody] SimpleReq req)
        {
            var res = new SingleRsp();
            res = categorySvc.Read(req.Id);
            return Ok(res);
        }

        [HttpPost("get-all")]
        public IActionResult getAllCategories()
        {
            var res = new SingleRsp();
            res.Data = categorySvc.All;
            return Ok(res);
        }

        [HttpGet]
        public IActionResult getAll()
        {
            var res = new SingleRsp();
            res.Data = categorySvc.All;
            return Ok(res);
        }
    }
}