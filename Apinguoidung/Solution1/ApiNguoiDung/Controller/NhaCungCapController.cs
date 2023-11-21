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
        [Route(("getAll_nhaCC"))]
        [HttpGet]
        public List<NhaCungCapModel> GetAllData()
        {
            return _nhaCCBul.GetAllNhaCC();
        }
    }
}
