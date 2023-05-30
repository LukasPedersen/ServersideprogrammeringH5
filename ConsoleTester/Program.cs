using ConsoleTester.Models;
using Microsoft.AspNetCore.SignalR.Client;

namespace ConsoleTester
{
    public class Program
    {
        [STAThread]
        static async void Main(string[] args)
        {
            await Console.Out.WriteAsync("Enter your username: ");
            string? username = await Console.In.ReadLineAsync();

            var connection = new HubConnectionBuilder()
            .WithUrl("http://localhost:5038/messagehub")
            .Build();

            try
			{
				await connection.StartAsync();
                await Console.Out.WriteLineAsync("Connected to NotificationHub");

                connection.On<NotifyMessage>("Notification", (message) =>
                {
                    Console.WriteLine($"{message.Username}: {message.Message}");
                });

                NotifyMessage notifyMessage = new NotifyMessage { Username = username};

                while (true)
                {
                    Console.WriteLine("Enter a message to send to the server");
                    var message = Console.ReadLine();
                    notifyMessage.Message = message;


                    await connection.InvokeAsync("SendMessage", notifyMessage);
                    Console.WriteLine("Message sent");
                    Console.ReadLine();
                }
            }
			catch (Exception ex)
			{
                Console.WriteLine(ex.Message);
            }
        }
    }
}