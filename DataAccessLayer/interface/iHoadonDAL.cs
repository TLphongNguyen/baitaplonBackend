using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;

namespace DataAccessLayer.interfaces
{
    public interface iHoadonDAL
    {

        bool create(HoadonModel hoadon);
        bool update(HoadonModel hoadon);
    }       
}
