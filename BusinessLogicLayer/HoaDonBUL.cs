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
    public class HoaDonBUL:IHoaDonBul
    {
        private iHoadonDAL _res;
        public HoaDonBUL(iHoadonDAL res)
        {
            _res = res;
        }

        
        public bool Create(HoadonModel model)
        {
            return _res.create(model);
        }
        public bool Update(HoadonModel model)
        {
            return _res.update(model);
        }
        
    }
}
