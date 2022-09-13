using CoffeeManagement.Common.BLL;
using CoffeeManagement.Common.Rsp;
using CoffeeManagement.DAL;
using CoffeeManagement.DAL.Models;
using System;
using System.Collections.Generic;
using System.Net;

namespace CoffeeManagement.BLL
{
    public class CategorySvc : GenericSvc<CategoryRep, Category>
    {
        #region -- Overrides --

        /// <summary>
        /// Read category by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override SingleRsp Read(int id)
        {
            var res = new SingleRsp();

            var m = _repository.Read(id);
            res.Data = m;

            return res;
        }

        /// <summary>
        /// Update category
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public override SingleRsp Update(Category m)
        {
            var res = new SingleRsp();

            var m1 = m.CategoryId > 0 ? _repository.Read(m.CategoryId) : _repository.Read(m.CategoryName);
            if (m1 == null)
            {
                res.SetError("EZ103", "No data.");
            }
            else
            {
                res = base.Update(m);
                res.Data = m;
            }

            return res;
        }

        public override SingleRsp Create(Category m)
        {
            return base.Create(m);
        }

        public override SingleRsp Read(string name)
        {
            return base.Read(name);
        }

        public override SingleRsp Delete(int id)
        {
            return base.Delete(id);
        }

        public override SingleRsp Delete(string code)
        {
            return base.Delete(code);
        }

        #endregion -- Overrides --

        #region -- Methods --

        public CategorySvc()
        { }

        #endregion -- Methods --
    }
}