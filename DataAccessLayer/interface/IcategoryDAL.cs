using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public interface IcategoryDAL
    {
        bool Create(categoryModel category);
        bool Update(categoryModel category);


    }
}
