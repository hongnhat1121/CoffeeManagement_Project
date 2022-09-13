using CoffeeManagement.Common.BLL;
using CoffeeManagement.Common.Req;
using CoffeeManagement.Common.Rsp;
using CoffeeManagement.DAL;
using CoffeeManagement.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;

namespace CoffeeManagement.BLL
{
    public class OrderSvc : GenericSvc<OrderRep, Order>
    {
        private OrderRep orderRep;
        private OrderDetailRep orderDetailRep;

        public OrderSvc()
        {
            orderRep = new OrderRep();
            orderDetailRep = new OrderDetailRep();
        }

        #region -- Overrides --

        /// <summary>
        /// Create a new order
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public override SingleRsp Create(Order m)
        {
            var res = new SingleRsp();
            res = _repository.CreateOrder(m);
            return res;
        }

        public override MultipleRsp Create(List<Order> l)
        {
            return base.Create(l);
        }

        public override SingleRsp Delete(int id)
        {
            if (_repository.OrderExists(id))
            {
                var res = new SingleRsp();
                res = base.Delete(id);
            }
            return null;
        }

        public override SingleRsp Delete(string code)
        {
            return base.Delete(code);
        }

        /// <summary>
        /// Read order by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override SingleRsp Read(int id)
        {
            var res = new SingleRsp();
            if (_repository.OrderExists(id))
            {
                var order = _repository.Read(id);
                res.Data = order;
            }
            return res;
        }

        public override int Remove(int id)
        {
            return base.Remove(id);
        }

        public override SingleRsp Restore(int id)
        {
            return base.Restore(id);
        }

        public override SingleRsp Restore(string code)
        {
            return base.Restore(code);
        }

        /// <summary>
        /// Update order by id or table name
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public override SingleRsp Update(Order m)
        {
            if (_repository.OrderExists(m.OrderId))
            {
                var res = new SingleRsp();
                var order = new Order();
                if (m.OrderId != 0)
                    order = _repository.Read(m.OrderId);
                else order = _repository.Read(m.Table.TableName);

                if (order != null)
                {
                    res = _repository.UpdateOrder(order);
                    return res;
                }
            }
            return null;
        }

        public override MultipleRsp Update(List<Order> l)
        {
            return base.Update(l);
        }

        #endregion -- Overrides --

        #region -- Methods --

        //public SingleRsp
        public SingleRsp StatsByYear(int year)
        {
            var res = new SingleRsp();
            //
            var result = from od in orderDetailRep.getAllOrderDetail()
                         join o in orderRep.FilterByYearOrder(year)
                         on od.OrderId equals o.OrderId
                         select new
                         {
                             Price = od.Price,
                             Quantity = od.Quantity,
                             Discount = od.Discount
                             //90 means 90%
                         };

            int? sum = 0;
            foreach (var od in result)
            {
                sum += (od.Price * od.Quantity) * ((100 - od.Discount) / 100);
            }

            res.Data = sum;
            return res;
        }

        #endregion -- Methods --
    }
}