using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class CategoryDAL:IcategoryDAL
    {
        private IDatabaseHelper _dbHelper;
        public CategoryDAL(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }
        public categoryModel GetCategorybyId(string id)
        {
            string msgError = "loi";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "Get_CategoryById",
                     "@IDcategory", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<categoryModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Create(categoryModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "create_Category",
                "@Namecategory", model.Namecategory
                
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
        public bool Update(categoryModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "update_category",
                "@IDcategory", model.IDcategory,
                "@Namecategory", model.Namecategory
                
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
        public List<categoryModel> Search(int pageIndex, int pageSize, out long total, string Name_category)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "Category_Search",
                    "@page_index", pageIndex,
                    "@page_size", pageSize,
                    "@NameCategory", Name_category
                    );
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<categoryModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<categoryModel> GetAllCategory()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "getALL_category");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<categoryModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
