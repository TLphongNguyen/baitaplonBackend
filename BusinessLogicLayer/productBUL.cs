using BusinessLogicLayer.interfaces;
using DataAccessLayer;
using DataAccessLayer.interfaces;
using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class productBUL:IproductBUL
    {
        private iProductDAL _res;
        
        public productBUL(iProductDAL res)
        {
            _res = res;
        }
       

        public bool Create(productModel model)
        {
            return _res.Create(model);
        }
        public bool Update(productModel model)
        {
            return _res.Update(model);
        }
        public bool Delete(productModel model)
        {
            return _res.Delete(model);
        }

    }
}
