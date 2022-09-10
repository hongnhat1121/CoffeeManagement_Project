//using CoffeeManagement.BLL;
//using CoffeeManagement.Common.Req;
//using CoffeeManagement.Common.Rsp;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace CoffeeManagement.Web.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class CategoryController : ControllerBase
//    {
//        private CategoryService categoryService;

//        public CategoryController()
//        {
//            categoryService = new CategoryService();
//        }

//        [HttpPost("get-by-id")]
//        public IActionResult GetCategoryById([FromBody] SimpleRequest request)
//        {
//            var response = new SingleResponse();
//            response = categoryService.Read(request.Id);
//            return Ok(response);
//        }

//        [HttpPost("get-all")]
//        public IActionResult GetAllCategories()
//        {
//            var response = new SingleResponse();
//            response.Data = categoryService.All;
//            return Ok(response);
//        }
//    }
//}