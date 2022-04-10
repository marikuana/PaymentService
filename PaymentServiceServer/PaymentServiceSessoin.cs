using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetCoreServer;
using Newtonsoft.Json;
using PaymentServiceServer.Controllers;

internal class PaymentServiceSessoin : TcpSession
{
    private Controller Controller { get; }

    public PaymentServiceSessoin(PaymentServiceServer.PaymentServiceServer server, Controller controller) : base(server)
    {
        Controller = controller;
    }

    public int AccountId { get; private set; }

    public void SetAccountId(int id)
    {
        AccountId = id;
    }

    protected override void OnReceived(byte[] buffer, long offset, long size)
    {
        string message = GetMessage(buffer, offset, size);

        Console.WriteLine(message);
        Callback? callback = JsonConvert.DeserializeObject<Callback>(message);
        if (callback == null)
            return;

        ViewModel vievModel = Controller.Invoke(this, callback);
        Callback responce = new Callback(callback.Command, vievModel);
        responce.Id = callback.Id;
        Send(responce);

    }

    public long Send(Callback callback) =>
        Send(JsonConvert.SerializeObject(callback));

    private string GetMessage(byte[] buffer, long offset, long size) =>
        Encoding.UTF8.GetString(buffer, (int)offset, (int)size);

}
