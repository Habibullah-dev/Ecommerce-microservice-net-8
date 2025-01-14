using Catalog.Application.Commands;
using Catalog.Application.Handlers;
using Catalog.Application.Queries;
using Catalog.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controller;


public class CatalogController : ApiController
{
    public CatalogController(IMediator sender) : base(sender)
    {
    }

    [HttpGet]
    [Route("[action]/{id}",Name = "GetProductById")]
    [ProducesResponseType(typeof(ProductResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<ProductResponse>> GetProductbyId(string id)  
    {
        var result = await _sender.Send(new GetProductByIdQuery(id));
        return Ok(result);
    }

    [HttpGet]
    [Route("[action]/{productName}",Name = "GetProductByProductName")]
    [ProducesResponseType(typeof(IList<ProductResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IList<ProductResponse>>> GetProductByProductName(string productName)  
    {
        var result = await _sender.Send(new GetProductsByNameQuery(productName));
        return Ok(result);
    }


    [HttpGet]
    [Route("[action]/{brandName}",Name = "GetProductByBrandName")]
    [ProducesResponseType(typeof(IList<ProductResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IList<ProductResponse>>> GetProductByBrandName(string brandName)  
    {
        var result = await _sender.Send(new GetProductsByBrandQuery(brandName));
        return Ok(result);
    }

    [HttpGet]
    [Route("GetAllProducts")]
    [ProducesResponseType(typeof(IList<ProductResponse>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IList<ProductResponse>>> GetAllProducts()  
    {
        var result = await _sender.Send(new GetAllProductQuery());
        return Ok(result);
    }


    [HttpGet]
    [Route("GetAllBrands")]
    [ProducesResponseType(typeof(IList<BrandResponse>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IList<BrandResponse>>> GetAllBrands()  
    {
        var result = await _sender.Send(new GetAllBrandsQuery());
        return Ok(result);
    }

    [HttpGet]
    [Route("GetAllTypes")]
    [ProducesResponseType(typeof(IList<ProductTypeResponse>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IList<ProductTypeResponse>>> GetAllTypes()  
    {
        var result = await _sender.Send(new GetAllProductTypesQuery());
        return Ok(result);
    }

    [HttpPost]
    [Route("CreateProduct")]
    [ProducesResponseType(typeof(ProductResponse), StatusCodes.Status201Created)]
    public async Task<ActionResult<ProductResponse>> AddProduct([FromBody] CreateProductCommand productRequest)  
    {
        var result = await _sender.Send(productRequest);
        return CreatedAtAction(nameof(GetProductbyId), new { id = result.Id }, result);
    }

    [HttpPut]
    [Route("UpdateProduct")]
    [ProducesResponseType(typeof(bool), StatusCodes.Status202Accepted)]
    public async Task<ActionResult<bool>> UpdateProduct([FromBody] UpdateProductCommand productRequest)  
    {
        var result = await _sender.Send(productRequest);
        return Accepted(result);
    }

    [HttpDelete]
    [Route("DeleteProduct/{id}", Name = "DeleteProduct")]
    [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
    public async Task<ActionResult<bool>> DeleteProduct(string id)  
    {
        var result = await _sender.Send(new DeleteProductCommand(id));
        return Ok(result);
    }
     
}