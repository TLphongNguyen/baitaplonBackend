using BUL.interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DataModel;

namespace ApiNguoiDung.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private ICustomerBUL _CTMBul;
        public CustomerController(ICustomerBUL CTMBul)
        {
            _CTMBul = CTMBul;

        }
        [Route(("get-by-id/{id}"))]
        [HttpGet]
        public CustomerModel GetDatabyID(string id)
        {
            return _CTMBul.GetByID(id);
        }
        [Route("create-Customer")]
        [HttpPost]
        public CustomerModel CreateItem([FromBody] CustomerModel model)
        {
            _CTMBul.create(model);
            return model;
        }
        [Route("update-Customer")]
        [HttpPost]
        public CustomerModel UpdateItem([FromBody] CustomerModel model)
        {
            _CTMBul.update(model);
            return model;
        }
    }
}
