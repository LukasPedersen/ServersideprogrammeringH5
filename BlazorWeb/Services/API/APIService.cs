using BlazorWeb.Services.Models;

namespace BlazorWeb.Services.API
{
    public class APIService : IAPIService
    {
        private readonly HttpClient _httpClient;
        public APIService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Telemetry>> GetTelementry(DateTime from, DateTime to)
        {
            HttpClient _httpClient = new();
            return await _httpClient.GetFromJsonAsync<List<Telemetry>>($"http://10.135.16.161:32768/getTelemetryByDate?from={from.ToString("MM/dd/yyyy HH:mm").Replace('.', ':')}&to={to.ToString("MM/dd/yyyy HH:mm").Replace('.', ':')}") ?? new List<Telemetry>();
        }
    }
}
