using WebSocketSharp;
using WebSocketSharp.Server;

namespace NgrokSpeedTestServer;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        var webSocketServer = new WebSocketServer(2000);
        webSocketServer.SslConfiguration.EnabledSslProtocols = System.Security.Authentication.SslProtocols.None;
        webSocketServer.AddWebSocketService<Server>("/");
        webSocketServer.Start();
        while (true)
        {
            var m = Console.ReadLine();
            if (m == "quit") break;
        }
        webSocketServer.Stop();
    }
}

public class Server : WebSocketBehavior
{
    protected override void OnMessage(MessageEventArgs e)
    {
        Send(e.RawData);
    }
}