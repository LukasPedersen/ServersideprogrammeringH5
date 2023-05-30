using BlazorWeb.Models;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.API
{
    public interface IAPIService
    {
        Task<List<Telemetry>> GetTelementry(DateTime from, DateTime to);
    }
}
