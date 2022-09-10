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
    public class EmployeeController : ControllerBase
    {
        private EmployeeSvc employeeSvc;
        public EmployeeController()
        {
            employeeSvc = new EmployeeSvc();
        }
        [HttpGet("get-all")]
        public IActionResult getAllEmployees()
        {
            var res = new SingleRsp();
            res.Data = employeeSvc.All;
            return Ok(res);
        }
        [HttpPost("get-by-id")]
        public IActionResult getEmployeeById(int id)
        {
            var res = new SingleRsp();
            res.Data = employeeSvc.Read(id);
            return Ok(res);
        }
    }
}
