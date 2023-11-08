using BusinessLogicLayer.interfaces;
using DataAccessLayer;
using DataModel;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace BusinessLogicLayer
{
    public class loginBUL:iLoginBUL
    {
        private iLogin _res;
        private string secret;

        public loginBUL(iLogin res, IConfiguration configuration)
        {
            _res = res;
            secret = configuration["AppSettings:Secret"];
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
        public Login login(string taikhoan, string matkhau)
        {
            var user = _res.login(taikhoan, matkhau);
            if (user == null)
                return null;
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Username.ToString()),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim("IDlogin", user.IDlogin.ToString()),
                    new Claim("MaLoai",user.Maloai.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.Aes128CbcHmacSha256)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.token = tokenHandler.WriteToken(token);
            user.Email = tokenHandler.WriteToken(token);
            return user;
        }
    }
}
