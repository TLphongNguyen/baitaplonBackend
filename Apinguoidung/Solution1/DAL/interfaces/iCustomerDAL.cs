using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.interfaces
{
    public interface iCustomerDAL
    {
        public CustomerModel GetByID(string id);
        bool create(CustomerModel model);
        bool update(CustomerModel model);
    }
}
