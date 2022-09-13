using CoffeeManagement.BLL;
using CoffeeManagement.Common.Req;
using CoffeeManagement.Common.Rsp;
using CoffeeManagement.DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.WebSockets;
using System.Threading.Tasks;

namespace CoffeeManagement.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController : ControllerBase
    {
        private readonly OrderDetailSvc orderDetailSvc;

        public OrderDetailController()
        {
            orderDetailSvc = new OrderDetailSvc();
        }

        // GET: api/OrderDetail
        [HttpGet("get-all")]
        public IActionResult GetOrderDetails()
        {
            var res = new SingleRsp();
            res.Data = orderDetailSvc.All;
            return Ok(res);
        }

        // GET: api/OrderDetail/{id}
        [HttpGet("{id}")]
        public IActionResult GetOrderDetail(int id)
        {
            //var orderDetail = await _context.OrderDetails.FindAsync(id);

            //if (orderDetail == null)
            //{
            //    return NotFound();
            //}

            //return orderDetail;

            if (id < 0)
            { return BadRequest("Order Id invalid"); }

            var res = new SingleRsp();
            res = orderDetailSvc.Read(id);

            if (res.Data == null)
            {
                return NotFound($"Order Detail with Order Id = {id} not found");
            }

            return Ok(res);
        }

        // PUT: api/OrderDetail/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateOrderDetail(int id, OrderDetail orderDetail)
        {
            //if (id != orderDetail.OrderId)
            //{
            //    return BadRequest();
            //}

            //_context.Entry(orderDetail).State = EntityState.Modified;

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!OrderDetailExists(id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            return null;
        }

        // POST: api/OrderDetail
        [HttpPost]
        public IActionResult CreateOrderDetail([FromBody] OrderDetailReq orderDetail)
        {
            //_context.OrderDetails.Add(orderDetail);
            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateException)
            //{
            //    if (OrderDetailExists(orderDetail.OrderId))
            //    {
            //        return Conflict();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            return CreatedAtAction("GetOrderDetail", new { id = orderDetail.OrderId }, orderDetail);
        }

        // DELETE: api/OrderDetail/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteOrderDetail(int id)
        {
            try
            {
                if (id < 0)
                    return BadRequest("Order Id invalid");
                var res = new SingleRsp();
                res = orderDetailSvc.Delete(id);

                if (res == null)
                {
                    return NotFound($"Order detail with Order Id = {id} not found");
                }

                return Content($"Order detail with Order Id = {id} deleted successfull");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting data");
            }
        }

        [HttpPost("revenue_by_productId_on_month_year")]
        public IActionResult Revenue(RevenueReq r)
        {
            var res = new SingleRsp();
            res = orderDetailSvc.Revenue(r);
            return Ok(res);
        }
    }
}