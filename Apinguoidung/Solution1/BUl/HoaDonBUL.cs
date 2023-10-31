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
        
        public List<thongkekhach> Search(int pageIndex, int pageSize, out long total, string ten_khach, DateTime? fr_NgayTao, DateTime? to_NgayTao)
        {
            return _res.Search(pageIndex, pageSize, out total, ten_khach, fr_NgayTao, to_NgayTao);
        }
    }
}
