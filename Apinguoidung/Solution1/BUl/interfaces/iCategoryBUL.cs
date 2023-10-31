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
        List<categoryModel> GetAllCategory();
    }
}
