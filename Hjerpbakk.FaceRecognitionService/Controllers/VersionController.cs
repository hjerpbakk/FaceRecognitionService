using System.Reflection;
using Microsoft.AspNetCore.Mvc;

namespace Hjerpbakk.FaceRecognitionService.Controllers
{
    [Route("api/[controller]")]
    public class VersionController : Controller
    {
        [HttpGet]
        public string Get()
        {
            return Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }
    }
}
