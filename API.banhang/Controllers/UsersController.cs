using BusinessLogicLayer.interfaces;
using DataModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.banhang.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private iLoginBUL _loginBUL;

        public UsersController(iLoginBUL loginBUL)
        {
            _loginBUL = loginBUL;
        }
        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login([FromBody] AuthenticateModel model)
        {
            var user = _loginBUL.login(model.Username, model.Password);
            if (user == null)
                return BadRequest(new { message = "Tài khoản hoặc mật khẩu không đúng!" });
            return Ok(new { taikhoan = user.Username, email = user.Email, token = user.token, });
        }
        [Route(("get-by-id/{id}"))]
        [HttpGet]
        public Login GetDatabyID(string id)
        {
            return _loginBUL.GetLoginbyId(id);
        }
        [Route("create-user")]
        [HttpPost]
        public Login CreateItem([FromBody] Login model)
        {
            _loginBUL.Create(model);
            return model;
        }
        [Route("update-khach")]
        [HttpPost]
        public Login UpdateItem([FromBody] Login model)
        {
            _loginBUL.Update(model);
            return model;
        }
    }
}
