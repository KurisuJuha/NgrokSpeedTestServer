using System.Net;
using System.Text;
using System.Net.WebSockets;
using System.Net.Sockets;

TcpListener listener = new TcpListener(IPAddress.Parse("127.0.0.1"), 3000);
listener.Start();
Socket socket = listener.AcceptSocket();