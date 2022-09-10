using CoffeeManagement.Common.BLL;
using CoffeeManagement.Common.Rsp;
using CoffeeManagement.DAL;
using CoffeeManagement.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeManagement.BLL
{
    public class ProductService : GenericService<ProductRepository, Product>
    {
        #region -- Overrides --

        public override SingleResponse Create(Product m)
        {
            return base.Create(m);
        }

        public override MultipleResponse Create(List<Product> l)
        {
            return base.Create(l);
        }

        public override SingleResponse Delete(int id)
        {
            return base.Delete(id);
        }

        public override SingleResponse Delete(string code)
        {
            return base.Delete(code);
        }

        public override SingleResponse Read(int id)
        {
            return base.Read(id);
        }

        public override SingleResponse Read(string code)
        {
            return base.Read(code);
        }

        public override int Remove(int id)
        {
            return base.Remove(id);
        }

        public override SingleResponse Restore(int id)
        {
            return base.Restore(id);
        }

        public override SingleResponse Restore(string code)
        {
            return base.Restore(code);
        }

        public override SingleResponse Update(Product m)
        {
            return base.Update(m);
        }

        public override MultipleResponse Update(List<Product> l)
        {
            return base.Update(l);
        }

        #endregion -- Overrides --
    }
}