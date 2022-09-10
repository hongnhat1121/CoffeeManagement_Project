using CoffeeManagement.Common.DAL;
using CoffeeManagement.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoffeeManagement.DAL
{
    public class CategoryRepository : GenericRepository<CoffeeManageDBContext, Category>
    {
        #region -- Overrides --

        public override Category Read(int id)
        {
            var res = All.FirstOrDefault(category => category.CategoryId == id);
            return res;
        }

        public override Category Read(string code)
        {
            return base.Read(code);
        }

        //public override Category Read(int id)
        //{
        //    return base.Read(id);
        //}

        public int Remove(int id)
        {
            var m = base.All.First(i => i.CategoryId == id);
            m = base.Delete(m);
            return m.CategoryId;
        }

        #endregion -- Overrides --
    }
}