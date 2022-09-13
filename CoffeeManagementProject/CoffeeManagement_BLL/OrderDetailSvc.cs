using CoffeeManagement.Common.BLL;
using CoffeeManagement.Common.Req;
using CoffeeManagement.Common.Rsp;
using CoffeeManagement.DAL;
using CoffeeManagement.DAL.Models;
using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Text;

namespace CoffeeManagement.BLL
{
    public class OrderDetailSvc : GenericSvc<OrderDetailRep, OrderDetail>
    {
        public OrderDetailSvc()
        {
        }

        #region -- Overrides --

        /// <summary>
        /// Create a new Order Detail
        /// </summary>
        /// <param name="orderDetail"></param>
        /// <returns></returns>
        public override SingleRsp Create(OrderDetail orderDetail)
        {
            if (!_repository.OrderDetailExists(orderDetail))
            {
                var res = new SingleRsp();
                res = _repository.CreateOrderDetail(orderDetail);
                return res;
            }
            return null;
        }

        public override SingleRsp Read(int id)
        {
            var res = new SingleRsp();
            res.Data = _repository.ReadOrderDetail(id);
            return res;
        }

        #endregion -- Overrides --

        #region -- Methods --

        /// <summary>
        /// Delete the Order Detail
        /// </summary>
        /// <param name="orderDetail"></param>
        /// <returns></returns>
        public SingleRsp Delete(OrderDetail orderDetail)
        {
            if (!_repository.OrderDetailExists(orderDetail))
            {
                var res = new SingleRsp();
                res = _repository.DeleteOrderDetail(orderDetail);
                return res;
            }
            return null;
        }

        public SingleRsp Revenue(RevenueReq revenueReq)
        {
            int total = 0;
            var res = new SingleRsp();
            var orders = _repository.ListOrderGetByProductId(
                revenueReq.Day, revenueReq.Month, revenueReq.Year,
                revenueReq.ProductId);
            foreach (var o in orders)
            {
                total += (int)(o.Price * o.Quantity * (1 - (o.Discount / 100)));
            }
            var item = new
            {
                Data = total,
                Day = revenueReq.Day,
                Month = revenueReq.Month,
                Year = revenueReq.Year,
                ProductId = revenueReq.ProductId
            };
            res.Data = item;
            return res;
        }

        #endregion -- Methods --
    }
}