using Catalog.Application.Commands;
using Catalog.Application.Handlers;
using Catalog.Application.Queries;
using Catalog.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controller;


public class CatalogController : ApiController
{
    public CatalogController(ISender sender) : base(sender)
    {
    }

    [HttpGet]
    [Route("[action]/{id:string}",Name = "GetProductById")]
    [ProducesResponseType(typeof(ProductResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetProductbyId(string id)  
    {
        var result = await _sender.Send(new GetProductByIdQuery(id));
        return Ok(result);
    }

    [HttpGet]
    [Route("[action]/{productName:string}",Name = "GetProductByProductName")]
    [ProducesResponseType(typeof(IList<ProductResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetProductByProductName(string productName)  
    {
        var result = await _sender.Send(new GetProductsByNameQuery(productName));
        return Ok(result);
    }


    [HttpGet]
    [Route("[action]/{brandName:string}",Name = "GetProductByBrandName")]
    [ProducesResponseType(typeof(IList<ProductResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetProductByBrandName(string brandName)  
    {
        var result = await _sender.Send(new GetProductsByBrandQuery(brandName));
        return Ok(result);
    }

    [HttpGet]
    [Route("GetAllProducts")]
    [ProducesResponseType(typeof(IList<ProductResponse>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllProducts()  
    {
        var result = await _sender.Send(new GetAllProductQuery());
        return Ok(result);
    }


    [HttpGet]
    [Route("GetAllBrands")]
    [ProducesResponseType(typeof(IList<BrandResponse>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllBrands()  
    {
        var result = await _sender.Send(new GetAllBrandsQuery());
        return Ok(result);
    }

    [HttpGet]
    [Route("GetAllTypes")]
    [ProducesResponseType(typeof(IList<BrandResponse>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllTypes()  
    {
        var result = await _sender.Send(new GetAllProductTypesQuery());
        return Ok(result);
    }

    [HttpPost]
    [Route("CreateProduct")]
    [ProducesResponseType(typeof(ProductResponse), StatusCodes.Status201Created)]
    public async Task<IActionResult> AddProduct([FromBody] CreateProductCommand productRequest)  
    {
        var result = await _sender.Send(productRequest);
        return CreatedAtAction(nameof(GetProductbyId), new { id = result.Id }, result);
    }

    [HttpPut]
    [Route("UpdateProduct")]
    [ProducesResponseType(typeof(bool), StatusCodes.Status202Accepted)]
    public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductCommand productRequest)  
    {
        var result = await _sender.Send(productRequest);
        return Accepted(result);
    }

    [HttpDelete]
    [Route("DeleteProduct/{id:string}", Name = "DeleteProduct")]
    [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
    public async Task<IActionResult> DeleteProduct(string id)  
    {
        var result = await _sender.Send(new DeleteProductCommand(id));
        return Ok(result);
    }
     
}