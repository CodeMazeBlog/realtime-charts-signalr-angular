using Microsoft.AspNetCore.SignalR;
using RealTimeCharts_Server.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RealTimeCharts_Server.HubConfig
{
    public class ChartHub : Hub
    {
        public async Task BroadcastChartData(List<ChartModel> data) => await Clients.All.SendAsync("broadcastchartdata", data);
    }
}
