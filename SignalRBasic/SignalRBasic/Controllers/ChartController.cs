using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalRChat.Hubs;

[Route("[controller]")]
[ApiController]
public class ChartController : ControllerBase
{
    private readonly IHubContext<ChatHub> _hub;
    private readonly TimerManager _timer;

    public ChartController(IHubContext<ChatHub> hub, TimerManager timer)
    {
        _hub = hub;
        _timer = timer;
    }

    [HttpGet]
    public IActionResult Get()
    {
        if (!_timer.IsTimerStarted)
            _timer.PrepareTimer(() => _hub.Clients.All.SendAsync("TransferChartData", DataManager.GetData()));
        return Ok(new { Message = "Request Completed" });
    }
}