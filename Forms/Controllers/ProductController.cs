
using Microsoft.AspNetCore.Mvc;

namespace Forms.Controllers;

[ApiController]
[Route("[Controller]")]
public class ProductController : Controller
{
    [HttpGet("product-controller")]
    public IActionResult Get([FromForm] string name,[FromForm] decimal price)
    {
        return Ok($"you are chose {name} product with ${price} price");
    }
}
