using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.interfaces
{
    public interface IHoaDonBul
    {
        HoadonModel GetDatabyID(string id);
        bool Create(HoadonModel model);
        bool Update(HoadonModel model);
        public List<thongkekhach> Search(int pageIndex, int pageSize, out long total, string ten_khach, DateTime? fr_NgayTao, DateTime? to_NgayTao);
    }
}
