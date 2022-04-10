using NetCoreServer;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace ClientSide
{
    public class PaymentServiceClient : NetCoreServer.TcpClient
    {
        public PaymentServiceClient(IPAddress address, int port) : base(address, port) { }

        private Dictionary<Guid, string?> request = new Dictionary<Guid, string?>();

        public Task<T> SendCallback<T>(Callback callback) where T : ViewModel 
        {
            Send(JsonConvert.SerializeObject(callback));
            request.Add(callback.Id, null);
            Task<T> task = Task.Run(() =>
            {
                while (true)
                {
                    if (request[callback.Id] != null)
                    {
                        T cb = JsonConvert.DeserializeObject<T>(request[callback.Id]);
                        request.Remove(callback.Id);
                        return cb;
                    }
                    Task.Delay(1);
                }
            });
            
            return task;
        }

        public long Send(Callback callback) =>
            Send(JsonConvert.SerializeObject(callback));

        public void DisconnectAndStop()
        {
            _stop = true;
            DisconnectAsync();
            while (IsConnected)
                Thread.Yield();
        }

        protected override void OnConnected()
        {
            Console.WriteLine($"Chat TCP client connected a new session with Id {Id}");
        }

        protected override void OnDisconnected()
        {
            Console.WriteLine($"Chat TCP client disconnected a session with Id {Id}");

            // Wait for a while...
            Thread.Sleep(1000);

            // Try to connect again
            if (!_stop)
                ConnectAsync();
        }

        protected override void OnReceived(byte[] buffer, long offset, long size)
        {
            string message = GetMessage(buffer, offset, size);

            Callback? callback = JsonConvert.DeserializeObject<Callback>(message);
            if (callback == null)
                return;

            if (request.ContainsKey(callback.Id))
            {
                request[callback.Id] = callback.ViewModel;
                return;
            }

            switch (callback.Command)
            {
                case CallbackCommand.ShowNotify:
                    MessageViewModel messageViewModel = ViewModel.Deserialize<MessageViewModel>(callback.ViewModel);
                    Notify notify = NotifyFactory.Create(messageViewModel);
                    notify.Send();
                    break;
                default:
                    MessageBox.Show("Unknown command", callback.Command, MessageBoxButton.OK, MessageBoxImage.Error);
                    break;
            }
        }

        private string GetMessage(byte[] buffer, long offset, long size) =>
            Encoding.UTF8.GetString(buffer, (int)offset, (int)size);

        protected override void OnError(SocketError error)
        {
            Console.WriteLine($"Chat TCP client caught an error with code {error}");
        }

        private bool _stop;
    }
}
