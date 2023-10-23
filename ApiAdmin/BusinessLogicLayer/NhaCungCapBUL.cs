using BusinessLogicLayer.interfaces;
using DataAccessLayer.interfaces;
using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class NhaCungCapBUL:iNhaCungCapBUL
    {
        private iNhaCCDAL _res;

        public NhaCungCapBUL(iNhaCCDAL res)
        {
            _res = res;
        }
        public NhaCungCapModel GetNhaCungCapByID(string id)
        {
            return _res.GetNhaCungCapByID(id);
        }
        public bool Create(NhaCungCapModel model)
        {
            return _res.Create(model);
        }
        public bool Update(NhaCungCapModel model)
        {
            return _res.Update(model);
        }
    }
}
