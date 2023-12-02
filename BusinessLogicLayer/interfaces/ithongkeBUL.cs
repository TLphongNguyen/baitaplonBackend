using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.interfaces
{
    public partial interface ithongkeBUL
    {
        ThongKeTongQuat ThongKe_Ngay();
        ThongKeTongQuat ThongKe_Tuan();
        ThongKeTongQuat ThongKe_Thang();
        ThongKeTongQuat ThongKe_Nam();
    }
}
