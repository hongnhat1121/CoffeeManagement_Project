using CoffeeManagement.Common.BLL;
using CoffeeManagement.Common.Rsp;
using CoffeeManagement.DAL;
using CoffeeManagement.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeManagement.BLL
{
    public class EmployeeSvc : GenericSvc<EmployeeRep, Employee>
    {
        public override SingleRsp Create(Employee m)
        {

            return base.Create(m);
        }

        public override MultipleRsp Create(List<Employee> l)
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
            var res = new SingleRsp();
            var model = _repository.Read(id);
            res.Data = model;
            return res;
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

        public override SingleRsp Update(Employee m)
        {
            return base.Update(m);
        }

        public override MultipleRsp Update(List<Employee> l)
        {
            return base.Update(l);
        }
    }
}
