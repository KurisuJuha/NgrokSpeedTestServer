using System.Net.Sockets;
using NetCoreServer;

public class GameSession : TcpSession
{
    public GameSession(TcpServer server) : base(server) { }

    protected override void OnConnected()
    {
        Console.WriteLine($"Connected: {Id}");
    }

    protected override void OnDisconnected()
    {
        Console.WriteLine($"Disconnected: {Id}");
    }

    protected override void OnReceived(byte[] buffer, long offset, long size)
    {
        Console.WriteLine($"Received: {Id}\n    {string.Join(",", buffer, offset, size)}");
        Send(buffer, offset, size);
    }

    protected override void OnError(SocketError error)
    {
        Console.WriteLine($"Error: {Id}");
    }
}