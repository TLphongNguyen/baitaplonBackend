using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.interfaces
{
    public interface iProductDAL
    {

        bool Create(productModel product);
        bool Update(productModel product);
        bool Delete(productModel product);
       
    }
}
