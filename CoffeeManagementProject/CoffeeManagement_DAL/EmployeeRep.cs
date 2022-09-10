using CoffeeManagement.Common.DAL;
using CoffeeManagement.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoffeeManagement.DAL
{
    public class EmployeeRep : GenericRep<QLCFContext, Employee>
    {
        public override Employee Read(int id)
        {
            var res = All.FirstOrDefault(e => e.EmployeeId == id);
            return res;
        }

        public override Employee Read(string code)
        {
            return base.Read(code);
        }
    }
}
