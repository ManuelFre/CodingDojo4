using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace CodingDojo4_Server.Communication
{
    class Server
    {
        private byte[] buffer = new byte[512];
        private Socket ServerSock, ClientSock;              //Socket- Klasse enthält sämtliche Methoden, welche für die TCP-Kommunikation benötigt werden.
        public Server()
        {
            ServerSock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            Trace.WriteLine("ServerSock erstellt");
            ServerSock.Bind(new IPEndPoint(IPAddress.Loopback, 8055));
            Trace.WriteLine("Binding auf IPEndpint erstellt");
            ServerSock.Listen(5);
            ClientSock = ServerSock.Accept();                   //Die Accept Methode verarbeitet jede eingehende Verbindungsanforderung und gibt einen Socket zurück, den Sie verwenden können, um Daten mit dem Remotehost zu kommunizieren
        }

        public String StartReceiving()
        {
            int length = ClientSock.Receive(buffer);
            string temp = Encoding.UTF8.GetString(buffer, 0, length);
            return temp;
        }
    }
}
