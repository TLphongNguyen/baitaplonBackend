using BusinessLogicLayer.interfaces;
using DataModel;
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
