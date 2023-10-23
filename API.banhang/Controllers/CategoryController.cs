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
        [Route(("get-by-id-category/{id}"))]
        [HttpGet]
        public categoryModel GetDatabyID(string id)
        {
            return _icategoryBUL.GetCategorybyId(id);
        }
        [Route("create-category")]
        [HttpPost]
        public categoryModel CreateItem([FromBody] categoryModel model)
        {
            _icategoryBUL.Create(model);
            return model;
        }
        [Route("update-category")]
        [HttpPost]
        public categoryModel UpdateItem([FromBody] categoryModel model)
        {
            _icategoryBUL.Update(model);
            return model;
        }
        [Route("search")]
        [HttpPost]
        public IActionResult Search([FromBody] Dictionary<string, object> formData)
        {
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                string Name_category = "";
                if (formData.Keys.Contains("NameCategory") && !string.IsNullOrEmpty(Convert.ToString(formData["NameCategory"])))
                {
                    Name_category = Convert.ToString(formData["NameCategory"]);
                }
                    long total = 0;
                    var data = _icategoryBUL.Search(page, pageSize, out total, Name_category);
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
        [Route("get-all")]
        [HttpGet]
        public List<categoryModel> getdata()
        {
            return _icategoryBUL.GetAllCategory();
        }
    }
}
