using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class thongkeHDnhap
    {
        public int MaSanPham { get; set; }
        public string TenSanPham { get; set; }
        public int SoLuong { get; set; }
        public Decimal TongGia { get; set; }
        public DateTime NgayTao { get; set; }
    }
}
