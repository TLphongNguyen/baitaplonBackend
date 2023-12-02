using DataAccessLayer.interfaces;
using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class ThongKeDAL:iThongKeDAL
    {
        private IDatabaseHelper _dbHelper;
        public ThongKeDAL(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }
        
        public ThongKeTongQuat ThongKe_Ngay()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "GetDailyRevenue");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<ThongKeTongQuat>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ThongKeTongQuat ThongKe_Tuan()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "GetWeeklyRevenue");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<ThongKeTongQuat>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ThongKeTongQuat ThongKe_Thang()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "GetMonthlyRevenue");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<ThongKeTongQuat>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ThongKeTongQuat ThongKe_Nam()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "GetYearlyRevenue");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<ThongKeTongQuat>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
