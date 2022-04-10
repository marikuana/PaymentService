using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class TieBankCardViewModel : ViewModel
{
    public string Number { get; set; }
    public DateTime Date { get; set; }
    public string Cvv { get; set; }

    public TieBankCardViewModel(string number, DateTime date, string cvv)
    {
        Number = number;
        Date = date;
        Cvv = cvv;
    }
}
