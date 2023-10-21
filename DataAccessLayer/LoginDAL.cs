using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class LoginDAL:iLogin
    {
        private IDatabaseHelper _dbHelper;
        public LoginDAL(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }
        public Login login(string taikhoan, string matkhau) {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_login",
                     "@Username", taikhoan,
                     "@Password", matkhau
                     );
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<Login>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Login GetLoginbyId(string id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "selectLoginbyId",
                     "@IDlogin", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<Login>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Create(Login model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "login_insert",
                "@Username", model.Username,
                "@Password", model.Password,
                "@MaLoai", model.MaLoai,
                "@Email",model.Email
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
        public bool Update(Login model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "tbl_login_Upd",
                "@IdLogin", model.IDlogin,
                "@Username", model.Username,
                "@Password", model.Password,
                "@MaLoai", model.MaLoai,
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
