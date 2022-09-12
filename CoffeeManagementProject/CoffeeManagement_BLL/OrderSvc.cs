using CoffeeManagement.Common.BLL;
using CoffeeManagement.Common.Rsp;
using CoffeeManagement.DAL;
using CoffeeManagement.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeManagement.BLL
{
    public class OrderSvc : GenericSvc<OrderRep, Order>
    {
        public OrderSvc()
        {
        }

        public override SingleRsp Create(Order m)
        {
            return base.Create(m);
        }

        public override MultipleRsp Create(List<Order> l)
        {
            return base.Create(l);
        }

        public override SingleRsp Delete(int id)
        {
            return base.Delete(id);
        }

        public override SingleRsp Delete(string code)
        {
            return base.Delete(code);
        }

        public override SingleRsp Read(int id)
        {
            return base.Read(id);
        }

        public override SingleRsp Read(string code)
        {
            return base.Read(code);
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

        public override SingleRsp Update(Order m)
        {
            return base.Update(m);
        }

        public override MultipleRsp Update(List<Order> l)
        {
            return base.Update(l);
        }
    }
}