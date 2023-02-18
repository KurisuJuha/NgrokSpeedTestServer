using WebSocketSharp;
using WebSocketSharp.Server;


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

public class Server : WebSocketBehavior
{
    protected override void OnClose(CloseEventArgs e)
        => Console.WriteLine("close");
    protected override void OnOpen()
        => Console.WriteLine("open");
    protected override void OnError(WebSocketSharp.ErrorEventArgs e)
        => Console.WriteLine("error");
    protected override void OnMessage(MessageEventArgs e)
        => Send(e.RawData);
}