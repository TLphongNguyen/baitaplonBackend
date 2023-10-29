using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.interfaces
{
    public interface IproductBUL
    {

        bool Create(productModel product);
        bool Update(productModel product);
        bool Delete(productModel product);

    }
}
