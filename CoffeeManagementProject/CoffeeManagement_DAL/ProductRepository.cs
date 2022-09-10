using CoffeeManagement.Common.DAL;
using CoffeeManagement.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoffeeManagement.DAL
{
    public class ProductRepository : GenericRepository<CoffeeManageDBContext, Product>
    {
        #region -- Overrides --

        public override Product Read(int id)
        {
            var response = All.FirstOrDefault(product => product.ProductId == id);
            return response;
        }

        public override Product Read(string code)
        {
            return base.Read(code);
        }

        #endregion -- Overrides --
    }
}