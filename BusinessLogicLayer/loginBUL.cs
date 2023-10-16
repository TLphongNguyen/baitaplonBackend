using BusinessLogicLayer.interfaces;
using DataAccessLayer;
using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class loginBUL:iLoginBUL
    {
        private iLogin _res;
        public loginBUL(iLogin res)
        {
            _res = res;
        }
        public Login GetLoginbyId(string id)
        {
            return _res.GetLoginbyId(id);
        }
        public bool Create(Login model)
        {
            return _res.Create(model);
        }
        public bool Update(Login model)
        {
            return _res.Update(model);
        }
    }
}
