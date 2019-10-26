using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using RealTimeCharts_Server.DataStorage;
using RealTimeCharts_Server.HubConfig;
using RealTimeCharts_Server.TimerFeatures;

namespace RealTimeCharts_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChartController : ControllerBase
    {
        private IHubContext<ChartHub> _hub; 

        public ChartController(IHubContext<ChartHub> hub) 
        { 
            _hub = hub;
        }

        public IActionResult Get()
        { 
            var timerManager = new TimerManager(() => _hub.Clients.All.SendAsync("transferchartdata", DataManager.GetData())); 
            
            return Ok(new { Message = "Request Completed" }); 
        }
    }
}