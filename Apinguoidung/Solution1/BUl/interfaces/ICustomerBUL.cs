using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUL.interfaces
{
    public interface ICustomerBUL
    {
        public CustomerModel GetByID(string id);
        bool create(CustomerModel model);
        bool update(CustomerModel model);
    }
}
