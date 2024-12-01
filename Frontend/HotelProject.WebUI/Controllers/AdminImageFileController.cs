using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace HotelProject.WebUI.Controllers
{
    public class AdminImageFileController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(IFormFile file)
        {
            var stream = new MemoryStream(); //flow creation
            await file.CopyToAsync(stream); //file copy from with flow
            var bytes = stream.ToArray(); //file into bytes

            ByteArrayContent byteArrayContent = new ByteArrayContent(bytes); 
            byteArrayContent.Headers.ContentType = new MediaTypeHeaderValue(file.ContentType);

            MultipartFormDataContent content = new MultipartFormDataContent();
            content.Add(byteArrayContent, "file", file.FileName);

            var httpClient = new HttpClient();
            await httpClient.PostAsync("http://localhost:41138/api/ImageFile", content);

            return View();
        }
    }
}
