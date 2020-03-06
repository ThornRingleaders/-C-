using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace 五子棋__完整版
{
    /// <summary>
    /// 提供网络通信服务
    /// </summary>
    class NetService
    {
        public const int SERVERPORT = 2000;
        
        public IPEndPoint ServerPoint
        {
            get {
                return new IPEndPoint(GetLocalIP(), SERVERPORT);
            }
            
        }


        /// <summary>
        /// 获取本机IP4地址
        /// </summary>
        /// <returns></returns>
        public static IPAddress GetLocalIP()
        {
            IPAddress[] ips = Dns.GetHostAddresses(Dns.GetHostName());
            for (int i = 0; i < ips.Length; i++)
            {
                if (ips[i].AddressFamily == AddressFamily.InterNetwork)
                {
                    return ips[i];
                }
            }

            return null;
        }
    }
}
