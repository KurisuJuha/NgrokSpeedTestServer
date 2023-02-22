using System;
using System.Net;
using System.Net.Sockets;
using NetCoreServer;

public class GameServer : TcpServer
{
    public GameServer(IPAddress address, int port) : base(address, port) { }

    protected override TcpSession CreateSession()
        => new GameSession(this);

    protected override void OnError(SocketError error)
    {
        Console.WriteLine($"ServerError: {error}");
    }
}