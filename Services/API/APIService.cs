using Services.Models;
using System.Net.Http.Json;

namespace Services.API
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
            return await _httpClient.GetFromJsonAsync<List<Telemetry>>($"https://jswzjk6b-7117.euw.devtunnels.ms/getTelemetryByDate?from={from.ToString("MM/dd/yyyy HH:mm").Replace('.', ':')}&to={to.ToString("MM/dd/yyyy HH:mm").Replace('.', ':')}") ?? new List<Telemetry>();
        }
    }
}
