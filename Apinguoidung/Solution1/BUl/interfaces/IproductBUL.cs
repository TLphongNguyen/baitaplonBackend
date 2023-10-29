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
        List<productModel> GetAllProduct();
        List<productModel> GetProductsBY(string ChucNang);
        List<productModel> GetProductsBYCategory(string IdCategory);

        public List<productModel> Search(int pageIndex, int pageSize, out long total, string Name_product);
    }
}
