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
        [HttpGet]
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
            var res = new SingleRsp();
            res = orderDetailSvc.Read(id);
            return Ok(res);
        }

        // PUT: api/OrderDetail/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderDetail(int id, OrderDetail orderDetail)
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

            return NoContent();
        }

        // POST: api/OrderDetail
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<OrderDetail>> PostOrderDetail(OrderDetail orderDetail)
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