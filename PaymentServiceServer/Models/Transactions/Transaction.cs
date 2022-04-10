using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class Transaction
{
    public int Id { set; get; }
    public Account Account { set; get; }
    public float AmountMoney { set; get; }
    public string Target { set; get; }
    public BankCard BankCard { set; get; }
    public DateTime Date { set; get; }
    public string Description { set; get; }

    public Transaction(BankCard bankCard, float amountMoney, string target, string description)
    {
        AmountMoney = amountMoney;
        Target = target;
        BankCard = bankCard;
        Date = DateTime.Now;
        Description = description;
    }

    public abstract string Image { get; }

    public Transaction() { }
}
