using Microsoft.AspNetCore.SignalR;
using RealTimeCharts.Server.Models;

namespace RealTimeCharts.Server.HubConfig
{
    public class ChartHub : Hub
    {
        public async Task BroadcastChartData(List<ChartModel> data, string connectionId) => 
            await Clients.Client(connectionId).SendAsync("broadcastchartdata", data);

        public string GetConnectionId() => Context.ConnectionId;
    }
}
