﻿using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.interfaces
{
    public interface InhapHangBUL
    {
        HoaDonNhapModel GetDatabyID(string id);
        bool create(HoaDonNhapModel hoadon);
        bool update(HoaDonNhapModel hoadon);
        List<HoaDonNhapModel> GetALl();
        List<HoaDonNhapModel> Search(int pageIndex, int pageSize, out long total, int ma_npp);
    }
}
