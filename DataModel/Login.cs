using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class Login
    {
        public int IDlogin { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int MaLoai { get; set; }
        public string Email { get; set; }
        public string token { get; set; }
    }
}
