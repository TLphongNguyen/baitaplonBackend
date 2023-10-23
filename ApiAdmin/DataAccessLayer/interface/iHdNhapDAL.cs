﻿using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.interfaces
{
    public interface iHdNhapDAL
    {
        HoaDonNhapModel GetDatabyID(string id);
        bool create(HoaDonNhapModel hoadon);
        bool update(HoaDonNhapModel hoadon);
    }
}
