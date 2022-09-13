using CoffeeManagement.Common.DAL;
using CoffeeManagement.DAL.Models;
using System.Linq;

namespace CoffeeManagement.DAL
{
    public class CategoryRep : GenericRep<CoffeeDBContext, Category>
    {
        #region -- Overrides --

        /// <summary>
        /// Read category by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Category</returns>
        public override Category Read(int id)
        {
            return All.FirstOrDefault(category => category.CategoryId == id);
        }

        /// <summary>
        /// Read category by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns>Category</returns>
        public override Category Read(string name)
        {
            return All.FirstOrDefault(category => category.CategoryName == name);
        }

        #endregion -- Overrides --

        #region -- Methods --

        /// <summary>
        /// Remove category
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int Remove(int id)
        {
            var m = base.All.First(i => i.CategoryId == id);
            m = base.Delete(m);
            return m.CategoryId;
        }

        #endregion -- Methods --
    }
}