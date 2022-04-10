using Newtonsoft.Json;
using System.Net.Sockets;
using System.Text;

public class Callback
{
    public Guid Id;
    public string Command;
    public StatusCode StatusCode;
    public string ViewModel;

    public Callback(string com, ViewModel viewModel) : this(com, viewModel.Serialize())
    {
        
    }

    public Callback(string com, string viewModel)
    {
        Id = Guid.NewGuid();
        Command = com;
        ViewModel = viewModel;
    }

    public Callback() { }
}


public enum StatusCode
{
    Success = 200,
    Error = 500,
}
