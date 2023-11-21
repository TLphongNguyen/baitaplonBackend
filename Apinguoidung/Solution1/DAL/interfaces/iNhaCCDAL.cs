using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.interfaces
{
    public interface iNhaCCDAL
    {
        NhaCungCapModel GetNhaCungCapByID(string id);
        List<NhaCungCapModel> GetAllNhaCC();
    }
}
