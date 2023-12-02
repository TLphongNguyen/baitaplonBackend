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
        [Route("get-by-id/{id}")]
        [HttpGet]
        public HoadonModel GetDatabyID(string id)
        {
            return _hoadonBusiness.GetDatabyID(id);
        }
        [Route("get-by-id-customer/{id}")]
        [HttpGet]
        public List<HoadonModel> GetDatabyIDCustomer(int id)
        {
            return _hoadonBusiness.GetDatabyIDCustomer(id);
        }

        [Route("search")]
        [HttpPost]
        public IActionResult Search([FromBody] Dictionary<string, object> formData)
        {
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                string ten_khach = "";
                if (formData.Keys.Contains("ten_khach") && !string.IsNullOrEmpty(Convert.ToString(formData["ten_khach"]))) { ten_khach = Convert.ToString(formData["ten_khach"]); }
                
                long total = 0;
                var data = _hoadonBusiness.Search(page, pageSize, out total, ten_khach);
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
