using BusinessLogicLayer;
using BusinessLogicLayer.interfaces;
using DataModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.banhang.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private iCategoryBUL _icategoryBUL;
        private string _path;
        private IWebHostEnvironment _env;
        public CategoryController(iCategoryBUL iCategoryBul, IConfiguration configuration, IWebHostEnvironment env)
        {
            _icategoryBUL = iCategoryBul;
            
            _env = env;
        }
        
        [Route(("get-by-id-category/{id}"))]
        [HttpGet]
        public categoryModel GetDatabyID(string id)
        {
            return _icategoryBUL.GetCategorybyId(id);
        }
        [Route("get-all")]
        [HttpGet]
        public List<categoryModel> getdata()
        {
            return _icategoryBUL.GetAllCategory();
        }





    }
}
