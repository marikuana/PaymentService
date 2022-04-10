using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using NetCoreServer;
using System.Reflection;
using PaymentServiceServer.Controllers;

namespace PaymentServiceServer
{
    internal class PaymentServiceServer : NetCoreServer.TcpServer
    {
        private Controller Controller { get; }

        public PaymentServiceServer(IPAddress address, int port) : base(address, port)
        {
            Controller = new Controller();
        }

        protected override TcpSession CreateSession() =>
            new PaymentServiceSessoin(this, Controller);

        public void Multicast(Callback callback) => 
            Multicast(Newtonsoft.Json.JsonConvert.SerializeObject(callback));

    }
}

