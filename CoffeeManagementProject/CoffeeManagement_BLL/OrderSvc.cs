using CoffeeManagement.Common.BLL;
using CoffeeManagement.Common.Rsp;
using CoffeeManagement.DAL;
using CoffeeManagement.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;

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
        /// Read order by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override SingleRsp Read(int id)
        {
            var order = _repository.Read(id);

            if (order != null)
            {
                var res = new SingleRsp();
                res.Data = order;
                return res;
            }

            return null;
        }

        /// <summary>
        /// Create a new order
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public override SingleRsp Create(Order m)
        {
            return _repository.CreateOrder(m);
        }

        /// <summary>
        /// Delete the order
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override SingleRsp Delete(int id)
        {
            var order = _repository.Read(id);
            if (order != null)
            {
                OrderDetailSvc orderDetailSvc = new OrderDetailSvc();
                orderDetailSvc.Delete(id);
                return _repository.DeleteOrder(order);
            }
            return null;
        }

        /// <summary>
        /// Update order by id or table name
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public override SingleRsp Update(Order m)
        {
            return _repository.UpdateOrder(m);
        }

        #endregion -- Overrides --

        #region -- Methods --

        /// <summary>
        /// Create a new order with order request
        /// </summary>
        /// <param name="orderReq"></param>
        /// <returns></returns>
        public SingleRsp Create(OrderReq orderReq)
        {
            var res = new SingleRsp();
            bool model = _repository.OrderExists(orderReq.OrderId);
            if (model == false)
            {
                Order order = new Order();
                order.OrderDate = DateTime.Now;
                order.CustomerId = orderReq.CustomerId;
                order.EmployeeId = orderReq.EmployeeId;

                return Create(order);
            }
            return null;
        }

        /// <summary>
        /// Update the order
        /// </summary>
        /// <param name="orderReq"></param>
        /// <returns></returns>
        public SingleRsp Update(OrderReq orderReq)
        {
            Order model = _repository.Read(orderReq.OrderId);

            if (model != null)
            {
                model.TableId = orderReq.TableId;
                return Update(model);
            }
            return null;
        }

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