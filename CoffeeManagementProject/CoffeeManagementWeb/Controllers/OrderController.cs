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

namespace CoffeeManagement.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderSvc orderSvc;

        public OrderController()
        {
            orderSvc = new OrderSvc();
        }

        // GET: api/Order
        [HttpGet]
        public IActionResult GetOrders()
        {
            var res = new SingleRsp();
            res.Data = orderSvc.All;
            return Ok(res);
        }

        // GET: api/Order/{id}
        [HttpGet("{id}")]
        public IActionResult GetOrder(int id)
        {
            try
            {
                if (id < 0)
                {
                    return BadRequest("Order Id invalid");
                }

                var res = new SingleRsp();
                res = orderSvc.Read(id);

                if (res.Data == null)
                {
                    return NotFound($"Order with Id = {id} not found");
                }
                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        // PUT: api/Order/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateOrder(int id, Order order)
        {
            if (id != order.OrderId)
            {
                return BadRequest("Order Id mismatch");
            }
            var res = new SingleRsp();
            res = orderSvc.Update(order);
            if (res == null)
                return NotFound($"Order with Id = {id} not found");
            return Ok(res);
        }

        // POST: api/Order
        [HttpPost]
        public IActionResult CreateOrder(Order order)
        {
            //_context.Orders.Add(order);
            //await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrder", new { id = order.OrderId }, order);
        }

        // DELETE: api/Order/5
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

            //return order;
            return NoContent();
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