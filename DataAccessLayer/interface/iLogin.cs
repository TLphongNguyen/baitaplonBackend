using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public partial interface iLogin
    {
        public Login GetLoginbyId(string id);
        bool Create(Login model);
        bool Update(Login model);
    }
}
