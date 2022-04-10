using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class BankCard
{
    public int Id { get; set; }
    public string Number { set; get; }
    public DateTime EndDate { set; get; }
    public string Cvv { set; get; }

    public BankCard(string number, DateTime endDate, string cvv)
    {
        Number = number;
        EndDate = endDate;
        Cvv = cvv;
    }

    public BankCard(TieBankCardViewModel bankCardViewModel) : this(bankCardViewModel.Number, bankCardViewModel.Date, bankCardViewModel.Cvv)
    {
    }
}
