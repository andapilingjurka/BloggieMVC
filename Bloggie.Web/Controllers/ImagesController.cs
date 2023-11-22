using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using test1.Repositories;

namespace test1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IImageRepository imageRepository;

        //ctor
        public ImagesController(IImageRepository imageRepository)
        {
            this.imageRepository = imageRepository;
        }

        [HttpPost]

        public async Task<IActionResult> UploadAsync(IFormFile file)
        {
            //call a repository
            var imageURL = await imageRepository.UploadAsync(file);
            if (imageURL == null)
            {
                return Problem("Something went wrong!", null, (int)HttpStatusCode.InternalServerError);
            }
            return new JsonResult(new { link = imageURL });

        }
    }


}

