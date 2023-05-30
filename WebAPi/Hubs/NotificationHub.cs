using ChillWathcerApp.Models;
using Microsoft.AspNetCore.SignalR;
using WebAPi.Models;

namespace WebAPi.Hubs
{
    public class NotificationHub : Hub
    {
        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception? exception)
        {
            return base.OnDisconnectedAsync(exception);
        }

        public async Task BoradcastNotification(string message)
        {
            await Clients.All.SendAsync("RecieveNotification", message);
        }
        public async Task UpdateLatestTelementry(Telemetry telemetry)
        {
            await Clients.All.SendAsync("UpdateTelementry", telemetry);
        }
    }
}
