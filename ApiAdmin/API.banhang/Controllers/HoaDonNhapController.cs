using BusinessLogicLayer;
using BusinessLogicLayer.interfaces;
using DataModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.banhang.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HoaDonNhapController : ControllerBase
    {
        private InhapHangBUL _NhapHangBUL;
        public HoaDonNhapController(InhapHangBUL NhapHangBUL)
        {
            _NhapHangBUL = NhapHangBUL;
        }
        [Route("get-by-id/{id}")]
        [HttpGet]
        public HoaDonNhapModel GetDatabyID(string id)
        {
            return _NhapHangBUL.GetDatabyID(id);
        }
        [Route("create-hoadon_nhap")]
        [HttpPost]
        public HoaDonNhapModel CreateItem([FromBody] HoaDonNhapModel model)
        {
            _NhapHangBUL.create(model);
            return model;
        }
        [Route("update-hoadon_nhap")]
        [HttpPost]
        public HoaDonNhapModel Update([FromBody] HoaDonNhapModel model)
        {
            _NhapHangBUL.update(model);
            return model;
        }

    }
}
