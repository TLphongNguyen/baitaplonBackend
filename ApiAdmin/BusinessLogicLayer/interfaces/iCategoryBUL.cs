using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.interfaces
{
    public interface iCategoryBUL
    {
        categoryModel GetCategorybyId(string id);
        bool Create(categoryModel category);
        bool Update(categoryModel category);
        public List<categoryModel> Search(int pageIndex, int pageSize, out long total, string Name_category);
        List<categoryModel> GetAllCategory();
    }
}
