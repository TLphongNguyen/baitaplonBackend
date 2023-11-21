using DAL.interfaces;
using DataAccessLayer;
using System;
using DataModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CustomerDAL:iCustomerDAL
    {
        private IDatabaseHelper _dbHelper;
        public CustomerDAL(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }
        public CustomerModel GetByID(int id)
        {
            string msgError = "loi get id";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "Get_Customer_byID",
                     "@MaChitietLogin", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<CustomerModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool create(CustomerModel model)
        {
            string msgError = "loi nhap";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "create_Customer",
                "@IDlogin", model.IDlogin,
                "@HoTen", model.HoTen,
                "@DiaChi", model.DiaChi,
                "@SoDienThoai", model.SoDienThoai,
                "@Avatar", model.Avatar,
                "@Email", model.Email



                );
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool update(CustomerModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "Update_Customer",
                "@MaChitietLogin", model.MaChitietLogin,
                "@IDlogin", model.IDlogin,
                "@HoTen", model.HoTen,
                "@DiaChi", model.DiaChi,
                "@SoDienThoai", model.SoDienThoai,
                "@Avatar", model.Avatar,
                "@Email", model.Email
                );
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
    
}
