using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CoffeeManagement.DAL.Models;
using CoffeeManagement.BLL;
using CoffeeManagement.Common.Rsp;
using CoffeeManagement.Common.Req;
using CoffeeManagement.DAL;

namespace CoffeeManagement.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly OrderSvc orderSvc;

        public OrdersController()
        {
            orderSvc = new OrderSvc();
        }

        // GET: api/Orders
        [HttpGet]
        public IActionResult GetOrders()
        {
            try
            {
                var res = new SingleRsp();
                res.Data = orderSvc.All;
                return Ok(res);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        // GET: api/Orders/{id}
        [HttpGet("{id}")]
        public IActionResult GetOrder(int id)
        {
            try
            {
                if (id < 0)
                    return BadRequest("Order Id invalid");

                var res = new SingleRsp();
                res = orderSvc.Read(id);

                if (res == null)
                    return NotFound($"Order with Id = {id} not found");
                return Ok(res);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        // PUT: api/Orders/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateOrder(int id, [FromBody] OrderReq orderReq)
        {
            if (id != orderReq.OrderId)
            {
                return BadRequest("Order Id mismatch");
            }

            var res = new SingleRsp();
            res = orderSvc.Update(orderReq);
            if (res == null)
                return NotFound($"Order with Id = {id} not found");
            return Ok(res);
        }

        // POST: api/Orders
        [HttpPost]
        public IActionResult CreateOrder([FromBody] OrderReq orderReq)
        {
            var res = new SingleRsp();
            res = orderSvc.Create(orderReq);
            return CreatedAtAction("GetOrderById", new { id = orderReq.OrderId }, res.Data);
        }

        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public IActionResult DeleteOrder(int id)
        {
            //var order = await _context.Orders.FindAsync(id);
            //if (order == null)
            //{
            //    return NotFound();
            //}

            //_context.Orders.Remove(order);
            //await _context.SaveChangesAsync();

            try
            {
                if (id < 0)
                    return BadRequest();
                var res = new SingleRsp();
                res = orderSvc.Delete(id);

                if (res == null)
                {
                    return NotFound();
                }

                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        [HttpPost("stats-by-year")]
        public IActionResult GetProductById([FromBody] StatsYearReq year)
        {
            var res = new SingleRsp();
            res = orderSvc.StatsByYear(year.Year);
            return Ok(res);
        }
    }
}