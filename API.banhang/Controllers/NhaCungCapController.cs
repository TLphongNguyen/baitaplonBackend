using BusinessLogicLayer.interfaces;
using DataModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.banhang.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NhaCungCapController : ControllerBase
    {
        private iNhaCungCapBUL _nhaCCBul;
        public NhaCungCapController(iNhaCungCapBUL nhaCCBul)
        {
            _nhaCCBul = nhaCCBul;
            
        }
        [Route(("get-by-id/{id}"))]
        [HttpGet]
        public NhaCungCapModel GetDatabyID(string id)
        {
            return _nhaCCBul.GetNhaCungCapByID(id);
        }
        [Route("create-NhaCC")]
        [HttpPost]
        public NhaCungCapModel CreateItem([FromBody] NhaCungCapModel model)
        {
            _nhaCCBul.Create(model);
            return model;
        }
        [Route("update-NhaCC")]
        [HttpPost]
        public NhaCungCapModel UpdateItem([FromBody] NhaCungCapModel model)
        {
            _nhaCCBul.Update(model);
            return model;
        }
    }
}
