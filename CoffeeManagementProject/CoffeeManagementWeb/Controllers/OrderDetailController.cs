using CoffeeManagement.BLL;
using CoffeeManagement.Common.Req;
using CoffeeManagement.Common.Rsp;
using CoffeeManagement.DAL.Models;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult GetOrderDetailByOrderId([FromBody] SimpleReq req)
        {
            //var orderDetail = await _context.OrderDetails.FindAsync(id);

            //if (orderDetail == null)
            //{
            //    return NotFound();
            //}

            //return orderDetail;

            if (req.Id < 0)
            { return BadRequest("Order Id invalid"); }

            var res = new SingleRsp();
            res = orderDetailSvc.Read(req.Id);

            if (res.Data == null)
            {
                return NotFound($"Order Detail with Order Id = {req.Id} not found");
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

        // DELETE: api/OrderDetail/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<OrderDetail>> DeleteOrderDetail(int id)
        {
            //var orderDetail = await _context.OrderDetails.FindAsync(id);
            //if (orderDetail == null)
            //{
            //    return NotFound();
            //}

            //_context.OrderDetails.Remove(orderDetail);
            //await _context.SaveChangesAsync();

            //return orderDetail;
            return null;
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