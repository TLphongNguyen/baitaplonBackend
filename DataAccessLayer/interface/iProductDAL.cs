using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.interfaces
{
    public interface iProductDAL
    {
        productModel GetProductbyId(string id);
        bool Create(productModel product);
        bool Update(productModel product);
        bool Delete(productModel product);
        List<productModel> GetAllProduct();
        //public List<productModel> Search(int pageIndex, int pageSize, out long total, string Name_product, string dia_chi);
    }
}
