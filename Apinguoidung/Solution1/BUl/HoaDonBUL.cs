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

        public HoadonModel GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }
        public List<HoadonModel> GetDatabyIDCustomer(int id)
        {
            return _res.GetDatabyIDCustomer(id);
        }
        public List<HoadonModel> Search(int pageIndex, int pageSize, out long total, string ten_khach)
        {
            return _res.Search(pageIndex, pageSize, out total, ten_khach);
        }
    }
}
