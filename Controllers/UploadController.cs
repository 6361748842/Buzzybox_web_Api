using BuzzyBox_Web_Api.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.IO;

namespace BuzzyBox_Web_Api.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class UploadController : ControllerBase
  {
    private readonly DataContext _context;

    private IHostEnvironment Environment;
    private IConfiguration Configuration;
    public UploadController(DataContext context, IHostEnvironment _environment, IConfiguration _configuration)
    {
      _context = context;
      Environment = _environment;
      Configuration = _configuration;
    }



    [HttpGet("{filename}")]
    public async Task<IActionResult> Get(string filename)
    {
      var imagefullpath = filename.Split("/");
      string path = System.IO.Directory.GetCurrentDirectory();
      var filePath = path + "\\" + filename;
      if (System.IO.File.Exists(filePath))
      {
        byte[] b = System.IO.File.ReadAllBytes(filePath);
        return File(b, "image/png");
      }
      return null;
    }

    //  [Authorize]
    [HttpPost]
    public IActionResult UploadImage(IFormFile postedFile)
    {
      if (postedFile != null)
      {
        //Create a Folder.
        string path = Path.Combine("Upload", "Images");
        if (!Directory.Exists(path))
        {
          Directory.CreateDirectory(path);
        }

        //Save the uploaded Excel file.
        string fileName = Path.GetFileName(postedFile.FileName);
        string filePath = Path.Combine(path, fileName);
        using (FileStream stream = new FileStream(filePath, FileMode.Create))
        {
          postedFile.CopyTo(stream);
        }
        return Ok(new { filePath });
      }

      return Ok();



    }
  }
}

