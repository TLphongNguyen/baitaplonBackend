using BusinessLogicLayer.interfaces;
using DataModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.banhang.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HoaDonController : ControllerBase
    {
        private IHoaDonBul _hoadonBusiness;
        public HoaDonController(IHoaDonBul hoadonBusiness)
        {
            _hoadonBusiness = hoadonBusiness;
        }
        
        [Route("create-hoadon")]
        [HttpPost]
        public HoadonModel CreateItem([FromBody] HoadonModel model)
        {
            _hoadonBusiness.Create(model);
            return model;
        }
        [Route("update-hoadon")]
        [HttpPost]
        public HoadonModel Update([FromBody] HoadonModel model)
        {
            _hoadonBusiness.Update(model);
            return model;
        }
        [Route("delete-hoadon/{idHoaDon}")]
        [HttpDelete]
        public IActionResult Delete(int idHoaDon)
        {
            try
            {
                var isDeleted = _hoadonBusiness.Delete(idHoaDon);

                if (isDeleted)
                {
                    return Ok($"Hóa đơn có ID {idHoaDon} đã được xoá thành công");
                }
                else
                {
                    return NotFound($"Không tìm thấy hoặc không xóa được hóa đơn có ID {idHoaDon}.");
                }
            }
            catch (Exception ex)
            {
                // Ghi log lỗi hoặc xử lý lỗi khác tùy theo yêu cầu của bạn
                return StatusCode(500, $"Lỗi ngoại lệ: {ex.Message}");
            }
        }
        

        
    }
}
