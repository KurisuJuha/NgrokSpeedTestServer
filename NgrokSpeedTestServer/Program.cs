using System.Net;

const int port = 8080;

Console.WriteLine($"port: {port}");
Console.WriteLine();

var server = new GameServer(IPAddress.Any, port);

Console.Write("Server starting..");
server.Start();
Console.WriteLine("..Done");

Console.ReadKey(true);

Console.Write("Server stopping..");
server.Stop();
Console.WriteLine("..Done");