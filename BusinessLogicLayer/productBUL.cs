using BusinessLogicLayer.interfaces;
using DataAccessLayer;
using DataAccessLayer.interfaces;
using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class productBUL:IproductBUL
    {
        private iProductDAL _res;
        
        public productBUL(iProductDAL res)
        {
            _res = res;
        }
       
        public productModel GetProductbyId(string id)
        {
            return _res.GetProductbyId(id);
        }
        public bool Create(productModel model)
        {
            return _res.Create(model);
        }
        public bool Update(productModel model)
        {
            return _res.Update(model);
        }
        public bool Delete(productModel model)
        {
            return _res.Delete(model);
        }
        public List<productModel> GetAllProduct()
        {
            return _res.GetAllProduct();
        }
        //public List<dynamic> GetAllJoin()
        //{

        //}

        //public List<productModel> Search(int pageIndex, int pageSize, out long total, string Name_product, string dia_chi)
        //{
        //    return _res.Search(pageIndex, pageSize, out total, Name_product, dia_chi);
        //}
    }
}
