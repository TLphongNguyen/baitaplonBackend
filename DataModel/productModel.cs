using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class productModel
    {
        public int IDproduct { get; set; }
        public string Nameproduct { get; set; }
        public int iDcategory { get; set; }
        public int SoLuong { get; set; }
        public string Imgproduct { get; set; }
        public int Priceproduct { get; set; }
        //public string Namecategory { get; set; }
        public int sale { get; set; }
    }
}
