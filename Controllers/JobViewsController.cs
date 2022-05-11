using JsonApiDotNetCore.Controllers.Annotations;
using Microsoft.AspNetCore.Mvc;
using PandoLogic.Services;

namespace PandoLogic.Controllers;

[ApiController]
[ApiExplorerSettings(IgnoreApi = true)]
[DisableRoutingConvention, Route("api/jobs-views")]
public class JobViewsController : ControllerBase
{
    private readonly IJobViewsMetaDataService _jobViewsMetaDataService;

    public JobViewsController(IJobViewsMetaDataService jobViewsMetaDataService) => _jobViewsMetaDataService = jobViewsMetaDataService;

    [HttpGet("GetMetaData")]
    public IActionResult GetAsync([FromQuery]DateTime startDate, [FromQuery]DateTime endDate, CancellationToken cancellationToken)
    {
        if (startDate >= endDate)
        {
            return BadRequest("Incorrect date rage");
        }

        var data = _jobViewsMetaDataService.GetMetaData(startDate, endDate, cancellationToken);
        
        return Ok(data);
    }
}