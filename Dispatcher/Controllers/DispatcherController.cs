using Dispatcher.Logical;
using Microsoft.AspNetCore.Mvc;
namespace Dispatcher.Controllers;

[ApiController]
public class DispatcherController : ControllerBase
{
    private readonly IDispatcherService _service;

    public DispatcherController(IDispatcherService service)
    {
        _service = service;
    }
    
    [HttpGet]
    [Route("GetResource")]
    public async Task<FileResult> Get(string url)
    {
        Guid messageId = new Guid();
        
        _service.SendUrl(url, messageId);

        return await _service.ReceiveFileAsync(messageId);
    }
}