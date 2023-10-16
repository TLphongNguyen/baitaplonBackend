using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class HoadonModel
    {
        public int IDhoadon { get; set; }
        public DateTime Datehoadon { get; set; }
        public string TenKH { get; set; }
        public string DiaChi { get; set; }
        public string SDTKH { get; set; }
        public string DiaChiNhanHang { get; set; }
    }
    public class ChiTietHoaDonModel
    {
        public int IdChiTietHoaDon { get; set; }
        public int IDhoadon { get; set; }
        public int IDproduct { get; set; }
        public int Soluong { get; set; }
        public float Dongia { get; set; }
    }
}
