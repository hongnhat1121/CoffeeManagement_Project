using CoffeeManagement.Common.DAL;
using CoffeeManagement.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeManagement.DAL
{
    public class OrderRep : GenericRep<QLCFContext, Order>
    {
        public override Order Read(int id)
        {
            return base.Read(id);
        }

        public override Order Read(string code)
        {
            return base.Read(code);
        }
    }
}