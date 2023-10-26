using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.interfaces
{
    public interface IproductBUL
    {
        productModel GetProductbyId(string id);
        bool Create(productModel product);
        bool Update(productModel product);
        bool Delete(productModel product);
        List<productModel> GetAllProduct();
        List<productModel> GetProductsBY(string ChucNang);
        List<productModel> GetProductsBYCategory(string IdCategory);

        //public List<productModel> Search(int pageIndex, int pageSize, out long total, string Name_product, string dia_chi);
    }
}
