using System;
using Fleck;

WebSocketServer server = new WebSocketServer("ws://0.0.0.0:3000");

server.Start(socket =>
{
    socket.OnOpen += () => Console.WriteLine("open");
    socket.OnClose += () => Console.WriteLine("close");
    socket.OnBinary += bytes => socket.Send(bytes);
    socket.OnMessage += message => socket.Send(message);
});

while (true) ;