using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ClientSide
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static PaymentServiceClient PaymentServiceClient { get; } = new PaymentServiceClient(System.Net.IPAddress.Loopback, 1234);

        public App()
        {
            PaymentServiceClient.ConnectAsync();
        }
    }
}
