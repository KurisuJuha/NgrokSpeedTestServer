using WebSocketSharp;
using WebSocketSharp.Server;


Console.WriteLine("Hello, World!");
var webSocketServer = new WebSocketServer(3000);
webSocketServer.AddWebSocketService<Server>("/");
webSocketServer.AllowForwardedRequest = true;
webSocketServer.Start();
while (true)
{
    var m = Console.ReadLine();
    if (m == "quit") break;
}
webSocketServer.Stop();

public class Server : WebSocketBehavior
{
    protected override void OnClose(CloseEventArgs e)
        => Console.WriteLine("close");
    protected override void OnOpen()
        => Console.WriteLine("open");
    protected override void OnError(WebSocketSharp.ErrorEventArgs e)
        => Console.WriteLine("error");
    protected override void OnMessage(MessageEventArgs e)
    {
        Console.WriteLine(System.Text.Encoding.UTF8.GetString(e.RawData));
        Send(e.RawData);
    }
}