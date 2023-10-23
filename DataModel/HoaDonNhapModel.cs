using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class HoaDonNhapModel
    {
        public int IDnhap { get; set; }
        public int IDlogin { get; set; }
        public DateTime Ngaynhap { get; set; }
        public int MaNhaCC { get; set; }
        public List<ChiTietHoaDonNhapModel> list_json_chitiethoadonNhap { get; set; }

    }
    public class ChiTietHoaDonNhapModel
    {
        public int IDctdn { get; set; }
        public int IDnhap { get; set; }
        public int IDproduct { get; set; }
        public int Soluong { get; set; }
        public int Gianhap { get; set; }
    }
}
