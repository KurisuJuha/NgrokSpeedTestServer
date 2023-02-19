using System.Text;
using SimpleTcp;

Console.WriteLine("Hello, World!");
var server = new SimpleTcpServer("localhost:8080");

server.Events.ClientConnected += (sender, e) => Console.WriteLine();
server.Events.ClientDisconnected += (sender, e) => Console.WriteLine($"[{e.IpPort}] client disconnected: {e.Reason}");
server.Events.DataReceived += (sender, e) =>
{
    Console.WriteLine($"[{e.IpPort}]: {string.Join(",", e.Data)}");
    server.Send(e.IpPort, e.Data);
};
server.Start();

while (true)
{
    var m = Console.ReadLine();
    if (m == "quit") break;
}