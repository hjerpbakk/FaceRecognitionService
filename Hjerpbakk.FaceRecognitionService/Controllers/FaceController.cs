using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Hjerpbakk.FaceRecognitionService.Clients;
using Hjerpbakk.FaceRecognitionService.Model;

namespace Hjerpbakk.FaceRecognitionService.Controllers
{
    [Route("api/[controller]")]
    public class FaceController : Controller
    {
        readonly IFaceRecognitionClient faceRecognitionClient;

        public FaceController(IFaceRecognitionClient faceRecognitionClient)
        {
            this.faceRecognitionClient = faceRecognitionClient;
        }

        [HttpPost]
        public async Task<FaceRecognitionResult> Post([FromBody]string url)
        {
            var urlToValidate = new Uri(url);
            return await faceRecognitionClient.ValidateProfileImage(urlToValidate);
        }
    }
}
