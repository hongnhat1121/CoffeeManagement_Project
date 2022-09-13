using CoffeeManagement.Common.DAL;
using CoffeeManagement.Common.Rsp;
using CoffeeManagement.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoffeeManagement.DAL
{
    public class OrderRep : GenericRep<CoffeeDBContext, Order>
    {
        public OrderRep()
        {
        }

        #region -- Overrides --

        /// <summary>
        /// Read order by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override Order Read(int id)
        {
            return All.FirstOrDefault(order => order.OrderId == id);
        }

        /// <summary>
        /// Read order by table name
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public override Order Read(string tableName)
        {
            return All.FirstOrDefault(order => order.Table.TableName == tableName);
        }

        #endregion -- Overrides --

        #region -- Methods --

        /// <summary>
        /// Create a new order
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public SingleRsp CreateOrder(Order order)
        {
            var res = new SingleRsp();

            using (var dBContext = new CoffeeDBContext())
            {
                using (var tran = dBContext.Database.BeginTransaction())
                {
                    try
                    {
                        var o = dBContext.Orders.Add(order);
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
        /// Update the order
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public SingleRsp UpdateOrder(Order order)
        {
            var res = new SingleRsp();

            using (var dBContext = new CoffeeDBContext())
            {
                using (var tran = dBContext.Database.BeginTransaction())
                {
                    try
                    {
                        var o = dBContext.Orders.Update(order);
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

        public SingleRsp DeleteOrder(int id)
        {
            var res = new SingleRsp();

            using (var dBContext = new CoffeeDBContext())
            {
                using (var tran = dBContext.Database.BeginTransaction())
                {
                    try
                    {
                        var o = dBContext.Orders;
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

        public bool OrderExists(int id)
        {
            return _dbContext.Orders.Any(order => order.OrderId == id);
        }

        public List<Order> getOrder(int day, int month, int year)
        {
            return All.Where(t => t.OrderDate.Value.Month == month && t.OrderDate.Value.Year == year).ToList();
        }

        public List<Order> FilterByYearOrder(int year)
        {
            return All.Where(o => o.OrderDate.Value.Year == year).ToList();
        }

        #endregion -- Methods --
    }
}