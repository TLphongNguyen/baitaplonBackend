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
    
        public bool Create(productModel model)
        {
            string msgError = "loi nhap";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "create_Product",
                "@Nameproduct", model.Nameproduct,
                "@IDcategory", model.iDcategory,
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
                "@IDcategory", model.iDcategory,
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
       
    }
}
