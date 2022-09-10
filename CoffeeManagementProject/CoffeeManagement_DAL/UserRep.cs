using CoffeeManagement.Common.DAL;
using CoffeeManagement.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeManagement.DAL
{
    public class UserRep : GenericRep<QLCFContext, User>
    {
        public override User Read(int id)
        {
            return base.Read(id);
        }

        public override User Read(string code)
        {
            return base.Read(code);
        }
    }
}
