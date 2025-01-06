using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controller;

[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiExplorerSettings(GroupName = "v1")]
[ApiController]
public class ApiController : ControllerBase 
{
    protected readonly ISender _sender;

    public ApiController(ISender sender)
    {
        _sender = sender;
    }

}