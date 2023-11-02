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

        
    }
}
