using DataAccessLayer.interfaces;
using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class NhaCungCapDAL:iNhaCCDAL
    {
        private IDatabaseHelper _dbHelper;
        public NhaCungCapDAL(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }
        public NhaCungCapModel GetNhaCungCapByID(string id)
        {
            string msgError = "loi";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "Get_NhaCungCapId",
                     "@IDNhaCungCap", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<NhaCungCapModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Create(NhaCungCapModel model)
        {
            string msgError = "loi nhap";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "create_NhaCungCap",
                "@TenNhaCC", model.TenNhaCC,
                "@diachiNhaCC", model.diachiNhaCC,
                "@SDTNhaCC", model.SDTNhaCC
                


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
        public bool Update(NhaCungCapModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "Update_NhaCungCap",
                "@IDNhaCungCap", model.MaNhaCC,
                "@TenNhaCC", model.TenNhaCC,
                "@diachiNhaCC", model.diachiNhaCC,
                "@SDTNhaCC", model.SDTNhaCC

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
