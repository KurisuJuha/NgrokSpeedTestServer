using WebSocketSharp;
using WebSocketSharp.Server;

namespace NgrokSpeedTestServer;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        var webSocketServer = new WebSocketServer(8080);
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
    protected override void OnClose(CloseEventArgs e)
    {
        base.OnClose(e);
        Console.WriteLine("close");
    }
    protected override void OnOpen()
    {
        base.OnOpen();
        Console.WriteLine("open");
    }
    protected override void OnError(WebSocketSharp.ErrorEventArgs e)
    {
        base.OnError(e);
        Console.WriteLine(e.Message);
        Console.WriteLine("error");
    }
    protected override void OnMessage(MessageEventArgs e)
    {
        Send(e.RawData);
    }
}