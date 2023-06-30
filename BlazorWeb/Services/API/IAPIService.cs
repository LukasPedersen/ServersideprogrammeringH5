using BlazorWeb.Services.Models;

namespace BlazorWeb.Services.API
{
    public interface IAPIService
    {
        Task<List<Telemetry>> GetTelementry(DateTime from, DateTime to);
    }
}
