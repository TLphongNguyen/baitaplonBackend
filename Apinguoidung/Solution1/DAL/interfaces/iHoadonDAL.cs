﻿using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;

namespace DataAccessLayer.interfaces
{
    public interface iHoadonDAL
    {
        HoadonModel GetDatabyID(string id);
        List<HoadonModel> GetDatabyIDCustomer(int id);
        public List<thongkekhach> Search(int pageIndex, int pageSize, out long total, string ten_khach, DateTime? fr_NgayTao, DateTime? to_NgayTao);
    }
}
