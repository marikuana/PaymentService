using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class AuthorizationViewModel : ViewModel
{
    public string Login { get;set; }
    public string Password { get;set; }

    public AuthorizationViewModel(string login, string password)
    {
        Login = login;
        Password = password;
    }
}

public class ViewModel
{
    public string Serialize()
    {
        return Newtonsoft.Json.JsonConvert.SerializeObject(this);
    }

    public static T Deserialize<T>(string json) where T : ViewModel
    {
        return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(json) ?? throw new ArgumentException();
    }
}
