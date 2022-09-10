using CoffeeManagement.Common.BLL;
using CoffeeManagement.Common.Rsp;
using CoffeeManagement.DAL;
using CoffeeManagement.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeManagement.BLL
{
    public class CategoryService : GenericService<CategoryRepository, Category>
    {
        #region -- Overrides --

        public override SingleResponse Read(int id)
        {
            var res = new SingleResponse();

            var m = _repository.Read(id);
            res.Data = m;

            return res;
        }

        public override SingleResponse Update(Category m)
        {
            var res = new SingleResponse();

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

        #endregion -- Overrides --

        #region -- Methods --

        public CategoryService()
        { }

        #endregion -- Methods --
    }
}