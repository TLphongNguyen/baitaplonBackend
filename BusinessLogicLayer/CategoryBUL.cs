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
        
        public bool Create(categoryModel model)
        {
            return _res.Create(model);
        }
        public bool Update(categoryModel model)
        {
            return _res.Update(model);
        }
     
    }
}
