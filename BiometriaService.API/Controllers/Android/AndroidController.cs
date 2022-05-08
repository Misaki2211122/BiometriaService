using System.ComponentModel;
using Application.Domains.Requests.Android;
using Application.Domains.Responses.Android;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace BiometriaService.API.Controllers.Android;

[ApiController]
[Route("/android/")]
[DisplayName("Управление андройд устройставами")]
[Produces("application/json")]
public class AndroidController: ControllerBase
{
    /// <summary>
    /// Request to handlers
    /// </summary>
    private readonly IMediator _mediator;

    /// <summary>
    /// AndroidController
    /// </summary>
    /// <param name="mediator">mediator</param>
    public AndroidController(IMediator mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    /// <summary>
    /// GetDeviceId
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("deviceIdAuthorize")] // название метода для обращения 
    [SwaggerResponse(StatusCodes.Status200OK, "Получение информации", typeof(DeviceIdAuthorizeRequest))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Возврат информации", typeof(DeviceIdAuthorizeResponse))]
    public async Task<IActionResult> DeviceIdAuthorize([FromForm] DeviceIdAuthorizeRequest request)
    {
        var resp = await _mediator.Send(request);

        if (resp.Success)
            return Ok(resp);
        else
            return BadRequest(resp);
    }
    
    /// <summary>
    /// GetDeviceId
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("getDeviceId")] // название метода для обращения 
    [SwaggerResponse(StatusCodes.Status200OK, "Получение информации", typeof(GetDeviceIdRequest))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Возврат информации", typeof(GetDeviceIdResponse))]
    public async Task<IActionResult> GetDeviceId([FromQuery] GetDeviceIdRequest request)
    {
        var resp = await _mediator.Send(request);

        if (resp.Success)
            return Ok(resp);
        else
            return BadRequest(resp);
    }
}