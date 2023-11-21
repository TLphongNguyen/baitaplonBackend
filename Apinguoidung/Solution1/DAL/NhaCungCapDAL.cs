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
        public List<NhaCungCapModel> GetAllNhaCC()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "getALL_NhaCC");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<NhaCungCapModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
