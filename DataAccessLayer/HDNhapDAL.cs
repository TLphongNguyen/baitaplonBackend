using DataAccessLayer.interfaces;
using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class HDNhapDAL : iHdNhapDAL
    {
        private IDatabaseHelper _dbHelper;
        public HDNhapDAL(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public HoaDonNhapModel GetDatabyID(string id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_NhapHang_get_by_id",
                     "@IDnhap", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<HoaDonNhapModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool create(HoaDonNhapModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_hoadonNhap_create",
                "@Idlogin", model.IDlogin,
                "@NgayNhap", model.Ngaynhap,
                "@MaNhaCC", model.MaNhaCC,
                "@list_json_chitiethoadonNhap", model.list_json_chitiethoadonNhap != null ? MessageConvert.SerializeObject(model.list_json_chitiethoadonNhap) : null);
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
        public bool update(HoaDonNhapModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_hoa_don_nhap_update",
                "@IDnhap", model.IDnhap,
                "@Idlogin", model.IDlogin,
                "@NgayNhap", model.Ngaynhap,
                "@MaNhaCC", model.MaNhaCC,
                "@list_json_chitiethoadonNhap", model.list_json_chitiethoadonNhap != null ? MessageConvert.SerializeObject(model.list_json_chitiethoadonNhap) : null);
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
        public List<HoaDonNhapModel> GetALl()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "usp_GetAllNhapHang");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<HoaDonNhapModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<HoaDonNhapModel>  Search(int pageIndex, int pageSize, out long total,int ma_npp) { 

            string msgError = "";
            total = 0;
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_hdn_search",
                    "@page_index", pageIndex,
                    "@page_size", pageSize,
                    "@ma_npp" , ma_npp
                     );
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<HoaDonNhapModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
