using Fleck;

WebSocketServer server = new WebSocketServer("ws://0.0.0.0:3000");
GameServer gameServer = new GameServer(server, 4);

gameServer.Start();

while (true) ;