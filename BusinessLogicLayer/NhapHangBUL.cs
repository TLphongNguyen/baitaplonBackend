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
    public class NhapHangBUL:InhapHangBUL
    {
        private iHdNhapDAL _res;
        public NhapHangBUL(iHdNhapDAL res)
        {
            _res = res;
        }
        public HoaDonNhapModel GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }
        public bool create(HoaDonNhapModel model)
        {
            return _res.create(model);
        }
        public bool update(HoaDonNhapModel model)
        {
            return _res.update(model);
        }

        public List<HoaDonNhapModel> Search(int pageIndex, int pageSize, out long total, int ma_npp)
        {
            return _res.Search(pageIndex, pageSize, out total, ma_npp);   
        }
        public List<HoaDonNhapModel> GetALl()
        {
            return _res.GetALl();
        }
    }
}
