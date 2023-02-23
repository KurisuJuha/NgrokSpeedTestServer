using Fleck;
using System;
using System.Timers;
using System.Collections.Generic;

public class GameServer
{
    public readonly int maxInputSize;
    public readonly WebSocketServer webSocketServer;
    private readonly Dictionary<Guid, Client> clients = new Dictionary<Guid, Client>();

    public GameServer(WebSocketServer webSocketServer, int maxInputSize)
    {
        this.webSocketServer = webSocketServer;
        this.maxInputSize = maxInputSize;
    }

    public void Start()
    {
        webSocketServer.Start(socket =>
        {
            socket.OnOpen += () =>
            {
                OnOpen(socket);
                Console.WriteLine("open");
            };
            socket.OnClose += () =>
            {
                OnClose(socket);
                Console.WriteLine("close");
            };
            socket.OnBinary += bytes => OnBinary(bytes, socket);
            socket.OnMessage += message => socket.Send(socket.ConnectionInfo.Id.ToString());
        });

        Timer timer = new Timer(1000 / 60);
        timer.Elapsed += (sender, e) =>
        {
            List<byte> bytes = new List<byte>();

            foreach (var key in clients.Keys)
            {
                bytes.AddRange(key.ToByteArray());
                bytes.AddRange(clients[key].lastInput);
            }

            BroadCast(bytes.ToArray());
        };
        timer.Start();
    }

    private void BroadCast(byte[] bytes)
    {
        foreach (var client in clients.Values)
        {
            client.lastSocket.Send(bytes);
        }
    }

    public void OnOpen(IWebSocketConnection socket)
    {
        clients[socket.ConnectionInfo.Id] = new Client(socket, maxInputSize);
    }

    public void OnClose(IWebSocketConnection socket)
    {
        clients.Remove(socket.ConnectionInfo.Id);
    }

    public void OnBinary(byte[] bytes, IWebSocketConnection socket)
    {
        clients[socket.ConnectionInfo.Id].lastInput = bytes;
    }
}