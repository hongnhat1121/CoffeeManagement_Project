using CoffeeManagement.Common.DAL;
using CoffeeManagement.Common.Rsp;
using CoffeeManagement.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;

namespace CoffeeManagement.DAL
{
    public class OrderDetailRep : GenericRep<CoffeeDBContext, OrderDetail>
    {
        public OrderDetailRep()
        {
        }

        #region -- Overrides --

        public override OrderDetail Read(int id)
        {
            return base.Read(id);
        }

        #endregion -- Overrides --

        #region -- Methods --

        /// <summary>
        /// Read Order Detail by OrderId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEnumerable<OrderDetail> ReadOrderDetail(int id)
        {
            return _dbContext.OrderDetails.Where(orderDetail => orderDetail.OrderId == id);
        }

        /// <summary>
        /// Read Order Detail by OrderId and ProductId
        /// </summary>
        /// <param name="orderDetail"></param>
        /// <returns></returns>
        public SingleRsp ReadOrderDetail(OrderDetail orderDetail)
        {
            var res = new SingleRsp();
            res.Data = All.FirstOrDefault(d => d.OrderId == orderDetail.OrderId && d.ProductId == orderDetail.ProductId);
            return res;
        }

        /// <summary>
        /// Create a new Order Detail
        /// </summary>
        /// <param name="orderDetail"></param>
        /// <returns></returns>
        public SingleRsp CreateOrderDetail(OrderDetail orderDetail)
        {
            var res = new SingleRsp();

            using (var dBContext = new CoffeeDBContext())
            {
                using (var tran = dBContext.Database.BeginTransaction())
                {
                    try
                    {
                        var o = dBContext.OrderDetails.Add(orderDetail);
                        dBContext.SaveChanges();
                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        res.SetError(ex.StackTrace);
                    }
                }
            }

            return res;
        }

        /// <summary>
        /// Update quantity, discount in order detail
        /// </summary>
        /// <param name="orderDetail"></param>
        /// <returns></returns>
        public SingleRsp UpdateOrderDetail(OrderDetail orderDetail)
        {
            var res = new SingleRsp();

            using (var dBContext = new CoffeeDBContext())
            {
                using (var tran = dBContext.Database.BeginTransaction())
                {
                    try
                    {
                        var o = dBContext.OrderDetails.Update(orderDetail);
                        dBContext.SaveChanges();
                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        res.SetError(ex.StackTrace);
                    }
                }
            }

            return res;
        }

        /// <summary>
        /// Delete Order Detail
        /// </summary>
        /// <param name="orderDetail"></param>
        /// <returns></returns>
        public SingleRsp DeleteOrderDetail(OrderDetail orderDetail)
        {
            var res = new SingleRsp();
            _dbContext.OrderDetails.Remove(orderDetail);
            return res;
        }

        public bool OrderDetailExists(OrderDetail orderDetail)
        {
            return All.Any(d => d.OrderId == orderDetail.OrderId && d.ProductId == orderDetail.ProductId);
        }

        private OrderRep temp = new OrderRep();

        public List<OrderDetail> ListOrderGetByProductId(int day, int month, int year, int productId)
        {
            List<OrderDetail> orderdetail = All.Where(t => t.ProductId == productId).ToList();
            List<Order> order = temp.getOrder(day, month, year);
            var orders = from od in orderdetail
                         join o in order
                         on od.OrderId equals o.OrderId
                         where o.OrderDate.Value.Month == month && od.ProductId == productId
                         select od;

            return orders.ToList();
        }

        public List<OrderDetail> getAllOrderDetail()
        {
            return All.ToList();
        }

        #endregion -- Methods --
    }
}