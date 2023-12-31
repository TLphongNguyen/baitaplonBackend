﻿using System;
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
        public string tenKH { get; set; }
        public string Diachi { get; set; }
        public string SDTKH { get; set; }
        public string DiaChiGiaoHang { get; set; }
        public List<ChiTietHoaDonModel> list_json_chitiethoadon { get; set; }
    }
    public class ChiTietHoaDonModel
    {
        public int IDchitiethd { get; set; }
        public int IDhoadon { get; set; }
        public int IDproduct { get; set; }
        public int Soluong { get; set; }
        public float Dongia { get; set; }
        public int status { get; set; }
    }
}
