using System;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UDPNodeManual_NETConsole
{
    class AppInfo
    {
        public const String AppName = "ClapeyronGoUDPp2pTest";
        public const double AppVersion = 0.1;

        /// <summary>
        /// IP компьютера в локальной сети.
        /// </summary>
        public static IPAddress LocalIP;

        static AppInfo()
        {
            try
            {
                String host = Dns.GetHostName();
                LocalIP = Dns.GetHostByName(host).AddressList[0];
            }
            catch (SocketException e)
            {
                Program.writeLine("Error: cant get a local IP info: "+ e.Message);
            }
        }
    }
}
