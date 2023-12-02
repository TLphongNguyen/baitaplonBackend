using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.interfaces
{
    public partial interface iThongKeDAL
    {
        ThongKeTongQuat ThongKe_Ngay();
        ThongKeTongQuat ThongKe_Tuan();
        ThongKeTongQuat ThongKe_Thang();
        ThongKeTongQuat ThongKe_Nam();
    }
}
