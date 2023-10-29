using BusinessLogicLayer;
using BusinessLogicLayer.interfaces;
using DataModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.banhang.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IproductBUL _IproductBUL;
        private string _path;
        private IWebHostEnvironment _env;
        public ProductController(IproductBUL iproductBUL, IConfiguration configuration, IWebHostEnvironment env)
        {
            _IproductBUL = iproductBUL;
            _path = configuration["AppSettings:PATH"];
            _env = env;
        }
        [NonAction]
        public string CreatePathFile(string RelativePathFileName)
        {
            try
            {
                string serverRootPathFolder = _path;
                string fullPathFile = $@"{serverRootPathFolder}\{RelativePathFileName}";
                string fullPathFolder = System.IO.Path.GetDirectoryName(fullPathFile);
                if (!Directory.Exists(fullPathFolder))
                    Directory.CreateDirectory(fullPathFolder);
                return fullPathFile;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [Route("upload")]
        [HttpPost, DisableRequestSizeLimit]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            try
            {
                if (file.Length > 0)
                {
                    string filePath = $"upload/{file.FileName}";
                    var fullPath = CreatePathFile(filePath);
                    using (var fileStream = new FileStream(fullPath, FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }
                    return Ok(new { filePath });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Không tìm thây");
            }
        }

        [Route("download")]
        [HttpPost]
        public IActionResult DownloadData([FromBody] Dictionary<string, object> formData)
        {
            try
            {
                var webRoot = _env.ContentRootPath;
                string exportPath = Path.Combine(webRoot + @"\Export\DM.xlsx");
                var stream = new FileStream(exportPath, FileMode.Open, FileAccess.Read);
                return File(stream, "application/octet-stream");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        [Route(("get-by-id-product/{id}"))]
        [HttpGet]
        public productModel GetDatabyID(string id)
        {
            return _IproductBUL.GetProductbyId(id);
        }
        [Route("getAll-product")]
        [HttpGet]
        public List<productModel> getData()
        {
            return _IproductBUL.GetAllProduct();

        }
        [Route(("get-by-ChucNang/{ChucNang}"))]
        [HttpGet]
        public List<productModel> getDataBy(string ChucNang)
        {
            return _IproductBUL.GetProductsBY(ChucNang);
        }
        [Route(("get-by-Category/{IdCategory}"))]
        [HttpGet]
        public List<productModel> getDataByIDCategory(string IdCategory)
        {
            return _IproductBUL.GetProductsBYCategory(IdCategory);
        }
        [Route("search")]
        [HttpPost]
        public IActionResult Search([FromBody] Dictionary<string, object> formData)
        {
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                string Name_product = "";
                if (formData.Keys.Contains("nameproduct") && !string.IsNullOrEmpty(Convert.ToString(formData["nameproduct"]))) { Name_product = Convert.ToString(formData["nameproduct"]); }
                string dia_chi = "";
               
                long total = 0;
                var data = _IproductBUL.Search(page, pageSize, out total, Name_product);
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
