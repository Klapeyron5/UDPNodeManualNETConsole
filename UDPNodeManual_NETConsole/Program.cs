using System;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UDPNodeManual_NETConsole
{
    class Program
    {
        private static UDPNode udpNode;

        static void Main(string[] args)
        {
            writeLine("Starts UDP manual node.");
            try
            {
                writeLine("Your IP is " + AppInfo.LocalIP);
                IPAddress ip = Dns.GetHostByName("localhost").AddressList[0];
                writeLine("Your localhost IP is " + ip);
            }
            catch (Exception e)
            {
                writeLine("Can't detect your localhost");
                writeLine(e.Message);
            }
            writeLine("Print <help> if u don't know what to do:");
            while (true)
            {
                consoleMenu(consoleReadLine());
            }
        }
        
        private static void consoleMenu(String task)
        {
            String[] splitTask = task.Split(' ');
            switch (splitTask[0])
            {
                case "help":
                    writeLine("startnode <outPort> <inPort>: starts local inPort listening and opportunity for sending messages from outPort");
                    writeLine("send <IP> <port> <data>: sends data to IP: port. <data> must be without spaces");
                    writeLine("closenode: closes started UDP socket");
                    writeLine("exit: closes the app");
                    break;
                    
                case "startnode":
                    try
                    {
                        int outPort = Int32.Parse(splitTask[1]);
                        int inPort = Int32.Parse(splitTask[2]);
                        udpNode = new UDPNode(outPort,inPort);
                    }
                    catch (Exception e)
                    {
                        writeLine("Error formatting: no correct port");
                    }
                    break;

                case "send":
                    try
                    {
                        String outIP = splitTask[1];
                        int outPort = Int32.Parse(splitTask[2]);
                        String outData = splitTask[3];
                        udpNode.sendNewString(outIP, outPort, outData);
                    }
                    catch (Exception e)
                    {
                        writeLine("Error formatting: no correct IP or port or data");
                        writeLine(e.Message);
                    }
                    break;

                case "closenode":
                    if (udpNode != null)
                        udpNode.closeNode();
                    break;

                case "exit":
                    udpNode.closeNode();
                    Environment.Exit(0);
                    break;

                default:
                    writeLine("Command does not exist");
                    break;
            }
        }

        public static void writeLine(String data)
        {
            Console.WriteLine(data);
        }

        private static String consoleReadLine()
        {
            return Console.ReadLine();
        }
    }
}
