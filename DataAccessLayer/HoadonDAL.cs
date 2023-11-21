using DataAccessLayer.interfaces;
using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class HoadonDAL : iHoadonDAL
    {
        private IDatabaseHelper _dbHelper;
        public HoadonDAL(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        
        public bool create(HoadonModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_hoadon_create",
                "@tenKH", model.tenKH,
                "@Diachi", model.Diachi,
                "@Datehoadon" ,model.Datehoadon,
                "@SDTKH", model.SDTKH,
                "@DiaChiNhanHang", model.DiaChiGiaoHang,
                "@list_json_chitiethoadon", model.list_json_chitiethoadon != null ? MessageConvert.SerializeObject(model.list_json_chitiethoadon) : null);
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
        public bool update(HoadonModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_hoa_don_update",
                "@MaHoaDon", model.IDhoadon,
                "@TenKH", model.tenKH,
                "@Diachi", model.Diachi,
                "@Datehoadon", model.Datehoadon,
                "@SDTKH", model.SDTKH,
                "@DiaChiNhanHang", model.DiaChiGiaoHang,
                "@list_json_chitiethoadon", model.list_json_chitiethoadon != null ? MessageConvert.SerializeObject(model.list_json_chitiethoadon) : null);
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
