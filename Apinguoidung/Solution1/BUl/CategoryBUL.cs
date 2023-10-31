using BusinessLogicLayer.interfaces;
using DataAccessLayer;
using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class CategoryBUL:iCategoryBUL

    {

        private IcategoryDAL _res;
        public CategoryBUL(IcategoryDAL rez)
        {
            _res = rez;
        }
        public categoryModel GetCategorybyId(string id)
        {
            return _res.GetCategorybyId(id);
        }
        public List<categoryModel> GetAllCategory()
        {
            return _res.GetAllCategory();
        }
    }
}
