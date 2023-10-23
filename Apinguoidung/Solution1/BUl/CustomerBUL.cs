using BUL.interfaces;
using DAL.interfaces;
using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUL
{
    public class CustomerBUL:ICustomerBUL 
    {
        private iCustomerDAL _res;
        
        public CustomerBUL(iCustomerDAL res)
        {
            _res = res;
        }
        public CustomerModel GetByID(string id)
        {
            return _res.GetByID(id);
        }
        public bool create(CustomerModel model)
        {
            return _res.create(model);

        }
        public bool update(CustomerModel model)
        {
            return _res.update(model);
        }
    }
}
