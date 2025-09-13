using Microsoft.AspNetCore.Mvc;

namespace RouteParameter.Controllers;

[ApiController]
[Route("[Controller]")]
public class ProductController : Controller
{
    [HttpGet("v0/{id:int}")]
    public ActionResult GetProduct(int id)
    {
        return Ok(id);
    }


    /// <summary>
    /// The route template is "v1/{id}" (token name = "id").
    /// The action parameter is named idv1. By default ASP.NET Core model binding matches route tokens to parameters by name.
    ///You use [FromRoute(Name = "id")] to tell the binder: "bind the route token named 'id' into this parameter idv1". That makes the action return the passed id correctly.
    ///Common problems you’ll see when you do this
    /// </summary>
    /// <param name="idv1">The identifier of the product to retrieve.</param>
    /// <returns>An <see cref="ActionResult"/> containing the product identifier with an HTTP 200 (OK) response, but with error result </returns>
    /// 
    [HttpGet("v1/{id:int}")]
    public ActionResult GetProductv1(int idv1)
    {
        return Ok(idv1);
    }

    /// <summary>
    /// We  use [FromRoute(Name = "id")] to tell the binder: "bind the route token named 'id' into this parameter idv1". That makes the action return the passed id correctly.
    /// </summary>
    /// <param name="idv1"></param>
    /// <returns></returns> <summary>
    
    [HttpGet("v2/{id:int}")]
    public ActionResult GetProductv2([FromRoute(Name="id")] int idv1)
    {
        return Ok(idv1);
    }
}