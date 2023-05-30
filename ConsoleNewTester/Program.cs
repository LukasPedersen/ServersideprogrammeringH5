using ChillWathcerApp.Models;
using ConsoleTester.Models;
using Microsoft.AspNetCore.SignalR.Client;
using System.Text.Json;


var connection = new HubConnectionBuilder()
.WithUrl("https://localhost:7034/Notifications")
.Build();

connection.On<Telemetry>("UpdateTelementry", telementry =>
{
    string json = JsonSerializer.Serialize<Telemetry>(telementry);
    Console.WriteLine($"Telementry: {json} \a");
});

await connection.StartAsync();




while (true)
{
    Console.ReadKey();
    Random random = new Random();
    Telemetry NewTelemetry = new Telemetry {Temperature = random.Next(18, 28), Humidity = random.Next(64, 88), Time = DateTime.Now};
    await connection.SendAsync("UpdateLatestTelementry", NewTelemetry);
}