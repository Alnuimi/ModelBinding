using System;
using Microsoft.AspNetCore.Mvc;
using QueryString.Model;

namespace QueryString.Controllers;

[ApiController]
[Route("[Controller]")]
public class ProductController : Controller
{
    /// <summary>
    /// Retrieves a product by its identifier. The "id" is bound from the query string
    /// (for example: /Product/v0?id=123). Returns 200 OK with the provided id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("v0")]
    public ActionResult GetProduct(int id)
    {
        return Ok(id);
    }


    /// <summary>
    /// Returns a paginated view of products. Binds "page" and "pageSize" from the query string
    /// (e.g., /Product/v1?page=1&pageSize=10) and returns a message showing the provided values.
    /// </summary>
    /// <param name="page"></param>
    /// <param name="pageSize"></param>
    /// <returns></returns>
    [HttpGet("v1")]
    public ActionResult GetProductv1([FromQuery(Name = "page")] int page, [FromQuery(Name = "pageSize")] int pageSize)
    {
        return Ok($"Showing {page} items of page {pageSize}");
    }


    /// <summary>
    /// Binds query string values to a SearchRequest instance (e.g., page, pageSize, filters)
    /// and returns the bound object. Use this endpoint to search or filter products via query parameters.
    /// and we can use AsParameters with Minimal API
    /// </summary>
    /// <param name="searchRequest"></param>
    /// <returns></returns>
    [HttpGet("product-complex-query")]
    public ActionResult GetProductv2([FromQuery] SearchRequest searchRequest)
    {
        return Ok(searchRequest);
    }
    
    [HttpGet("product-dateRange")]
    public ActionResult GetProductv3(DateRangeQuery dateRange)
    {
        return Ok(dateRange);
    }

}
