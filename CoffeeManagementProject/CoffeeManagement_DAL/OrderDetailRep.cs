using CoffeeManagement.Common.DAL;
using CoffeeManagement.Common.Rsp;
using CoffeeManagement.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoffeeManagement.DAL
{
    public class OrderDetailRep : GenericRep<CoffeeDBContext, OrderDetail>
    {
        public OrderDetailRep()
        {
        }

        #region -- Overrides --

        //public override OrderDetail Read(int id)
        //{
        //    return base.Read(id);
        //}

        #endregion -- Overrides --

        #region -- Methods --

        /// <summary>
        /// Read Order Detail by OrderId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEnumerable<OrderDetail> ReadOrderDetails(int id)
        {
            return _dbContext.OrderDetails.Where(orderDetail => orderDetail.OrderId == id);
        }

        /// <summary>
        /// Read Order Detail by OrderId and ProductId
        /// </summary>
        /// <param name="orderDetail"></param>
        /// <returns></returns>
        public OrderDetail ReadOrderDetail(OrderDetail orderDetail)
        {
            return All.FirstOrDefault(d => d.OrderId == orderDetail.OrderId && d.ProductId == orderDetail.ProductId);
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
        /// Get Order Detail by Product Id
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public IEnumerable<OrderDetail> GetOrderDetailByProduct(Product product)
        {
            return _dbContext.OrderDetails.Where(orderDetail => orderDetail.ProductId == product.ProductId);
        }

        /// <summary>
        /// Get Order Detail by OrderId
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public IEnumerable<OrderDetail> ReadOrderDetailByOrder(Order order)
        {
            return _dbContext.OrderDetails.Where(orderDetail => orderDetail.OrderId == order.OrderId);
        }

        /// <summary>
        /// Delete Order Detail by OrderId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public SingleRsp DeleteOrderDetail(int id)
        {
            var res = new SingleRsp();

            using (var dBContext = new CoffeeDBContext())
            {
                using (var tran = dBContext.Database.BeginTransaction())
                {
                    try
                    {
                        var orderDetails = from d in dBContext.OrderDetails
                                           where d.OrderId == id
                                           select d;
                        dBContext.OrderDetails.RemoveRange(orderDetails);
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

            using (var dBContext = new CoffeeDBContext())
            {
                using (var tran = dBContext.Database.BeginTransaction())
                {
                    try
                    {
                        var o = dBContext.OrderDetails.Remove(orderDetail);
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