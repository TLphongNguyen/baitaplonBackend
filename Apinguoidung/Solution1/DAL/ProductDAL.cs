using DataAccessLayer.interfaces;
using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class ProductDAL:iProductDAL
    {
        private IDatabaseHelper _dbHelper;
        public ProductDAL(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }
        public productModel GetProductbyId(string id)
        {
            string msgError = "loi";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "GetPrdByID",
                     "@IDproduct", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<productModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                    throw ex;
            }
        }
        
        public List<productModel> GetAllProduct()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "getALL_product_join");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<productModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<productModel> GetProductsBY(string ChucNang)
        {
            string msgError = "loi";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_LaySanPhamTheoChucNang",
                     "@ChucNang", ChucNang);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<productModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<productModel> GetProductsBYCategory(string IdCategory)
        {
            string msgError = "loi";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "GetPrdByCategoryID",
                     "@MaLoai", IdCategory);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<productModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<productModel> Search(int pageIndex, int pageSize, out long total, string Name_product)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "products_search",
                    "@page_index", pageIndex,
                    "@page_size", pageSize,
                    "@Nameproduct", Name_product);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<productModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
