using BusinessLogicLayer.interfaces;
using DataAccessLayer.interfaces;
using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class ThongKeBUL: ithongkeBUL
    {
        private iThongKeDAL _res;
        public ThongKeBUL(iThongKeDAL res)
        {
            _res = res;
        }
        //public List<ThongKeTongQuat_Ngay> GetAll()
        //{
        //    return _res.GetAll();
        //}
        public ThongKeTongQuat ThongKe_Ngay()
        {
            return _res.ThongKe_Ngay();
        }
        public ThongKeTongQuat ThongKe_Tuan()
        {
            return _res.ThongKe_Tuan();
        }
        public ThongKeTongQuat ThongKe_Thang()
        {
            return _res.ThongKe_Thang();
        }
        public ThongKeTongQuat ThongKe_Nam()
        {
            return _res.ThongKe_Nam();
        }
    }
}
