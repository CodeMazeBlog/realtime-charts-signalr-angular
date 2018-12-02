using Microsoft.AspNetCore.SignalR;
using RealTimeCharts_Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealTimeCharts_Server.HubConfig
{
    public class ChartHub: Hub
    {
        public async Task SendChartData(List<ChartModel> data) => await Clients.All.SendAsync("receivechartdata", data);
    }
}
