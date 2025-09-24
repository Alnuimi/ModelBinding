
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Forms.Controllers;

[ApiController]
[Route("[Controller]")]
public class ProductController : Controller
{
    [HttpGet("product-controller")]
    public IActionResult Get([FromForm] string name, [FromForm] decimal price)
    {
        return Ok($"you are chose {name} product with ${price} price");
    }

    [HttpPost("upload-controller")]
    public async Task<IActionResult> Post(IFormFile file)
    {
        if (file is null || file.Length == 0)
            return Content("file not selected");
        var pathUpload = Path.Combine(Directory.GetCurrentDirectory(), "uploads");
        if (!Directory.Exists(pathUpload))
            Directory.CreateDirectory(pathUpload);
        var filePath = Path.Combine(pathUpload, file.FileName);
        using var stream = new FileStream(filePath, FileMode.Create);
        await file.CopyToAsync(stream);
        return Ok(new { file.FileName, file.Length });
    }
}
