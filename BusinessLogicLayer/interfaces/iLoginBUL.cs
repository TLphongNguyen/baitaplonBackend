using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.interfaces
{
    public partial interface iLoginBUL
    {
        public Login GetLoginbyId(string id);
        bool Create(Login model);
        bool Update(Login model);
        public Login login(string taikhoan, string matkhau);
    }
}
