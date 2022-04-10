using PaymentServiceServer;

namespace PaymentServiceServer
{
    static class Startup
    {
        private static void Main(string[] args)
        {
            using PaymentServiceServer serviceServer = new PaymentServiceServer(System.Net.IPAddress.Loopback, 1234);
            serviceServer.Start();
            while (true)
            {
                string? command = Console.ReadLine();
                if (string.IsNullOrEmpty(command))
                    continue;
                switch (command)
                {
                    case "stop":
                        serviceServer.Stop();
                        break;
                    default:
                        Callback callback = new Callback(CallbackCommand.ShowNotify, new MessageViewModel(NotifyType.Test));
                        serviceServer.Multicast(callback);
                        break;
                }
            }
        }
    }
}

