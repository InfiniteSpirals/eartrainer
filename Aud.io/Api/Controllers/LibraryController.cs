using Aud.io.Models.AudioLibrary;
using Microsoft.AspNetCore.Mvc;

namespace Aud.io.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public LibraryController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }


        [HttpGet]
        public JsonResult GetLibrary()
        {
            // Map Path
            string path = Path.Combine(_webHostEnvironment.WebRootPath, "audio");

            // create return model
            var model = new List<AudioLibraryCategoryModel>();

            // list all directories
            var directories = Directory.GetDirectories(path);


            foreach(var d in directories)
            {
                // dir name
                var dirName = Path.GetFileName(d);
                // get all the tracks
                var tracks = Directory.GetFiles(d).Select(x => new AudioLibraryEntryModel() { Filename = Path.GetFileName(x), Filepath = $"/audio/{dirName}/{Path.GetFileName(x)}" });

                // create a directory model
                model.Add(new AudioLibraryCategoryModel() { Label = dirName, Tracks = tracks });
            }
            
            return Json(model);
        }
    }
}
