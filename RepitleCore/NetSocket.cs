using System;
using System.Net.Sockets;
using System.Net;
using System.Threading.Tasks;

namespace RepitleCore
{
    /// <summary>
    /// 用来发出http 请求
    /// </summary>
    public class NetHttp
    {
        private Socket socket;

        [Obsolete]
        public NetHttp(string host)
        {
            

            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            int port = 80;
 

            string ipaddr = PaserIpaddr(host.Split("//")[1].Split("/")[0]);
            if (host.Contains("https"))
            {
                port = 443;
            }
 
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(ipaddr),port);
            

            socket.Connect(endPoint);
        }

        public async Task<IRepitResponse> RequestAsync(byte[] req)
        {
          return await Task<IRepitResponse>.Run(() =>
            {
                socket.Send(req);

                   
                return new RepitRespon(socket);
            });


        }

        [Obsolete]
        public string PaserIpaddr(string host)
        { 
            return Dns.GetHostByName(host).AddressList[0].ToString();
        }
    }
}
