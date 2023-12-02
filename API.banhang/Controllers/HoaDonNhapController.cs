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
        [Route("getALl")]
        [HttpGet]
        public List<HoaDonNhapModel> GetALl()
        {
            return _NhapHangBUL.GetALl();
        }
        [Route("search")]
        [HttpPost]
        public IActionResult Search([FromBody] Dictionary<string, object> formData)
        {
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                string name_product = "";
                int ma_npp = int.Parse(formData["ma_npp"].ToString());
                long total = 0;
                var data = _NhapHangBUL.Search(page, pageSize, out total,ma_npp);
                return Ok(
                    new
                    {
                        TotalItems = total,
                        Data = data,
                        Page = page,
                        PageSize = pageSize
                    }
                    );
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
