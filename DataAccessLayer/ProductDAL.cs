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
        public bool Create(productModel model)
        {
            string msgError = "loi nhap";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "create_Product",
                "@Nameproduct", model.Nameproduct,
                "@IDcategory", model.IDcategory,
                "@SoLuong", model.SoLuong,
                "@Imgproduct", model.Imgproduct,
                "@Priceproduct", model.@Priceproduct,
                "@sale", model.sale


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
        public bool Update(productModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "Update_Product",
                "@IDproduct", model.IDproduct,
                "@Nameproduct", model.Nameproduct,
                "@IDcategory", model.IDcategory,
                "@SoLuong", model.SoLuong,
                "@Imgproduct", model.Imgproduct,
                "@Priceproduct", model.@Priceproduct,
                "@sale", model.sale

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
        public bool Delete(productModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "delete_product",
                "@IDproduct", model.IDproduct
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
        //public List<productModel> Search(int pageIndex, int pageSize, out long total, string Name_product, string dia_chi)
        //{
        //    string msgError = "";
        //    total = 0;
        //    try
        //    {
        //        var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_khach_search",
        //            "@page_index", pageIndex,
        //            "@page_size", pageSize,
        //            "@ten_khach", Name_product,
        //            "@dia_chi", dia_chi);
        //        if (!string.IsNullOrEmpty(msgError))
        //            throw new Exception(msgError);
        //        if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
        //        return dt.ConvertTo<productModel>().ToList();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
    }
}
