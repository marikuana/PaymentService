using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Account
{
    public int Id { set; get; }
    public string Login { set; get; }
    public string Password { set; get; }
    public DateTime Create { set; get; }
    public BankCard? BankCard { set; get; }
    public List<Transaction> TransactionList { set; get; }

    public Account(string login, string password)
    {
        Login = login;
        Password = password;
        Create = DateTime.Now;
        TransactionList = new List<Transaction>();
    }

    public Account(RegistrationViewModel registration) : this(registration.Login, registration.Password)
    {

    }

    public Transaction? Transaction(TransactionRequestViewModel transactionRequest)
    {
        if (BankCard == null)
            return null;
        Transaction transaction = transactionRequest.TransactionType switch
        {
            TransactionType.BankCard => new BankTransaction(BankCard, transactionRequest.Money, transactionRequest.Target),
            TransactionType.Phone => new PhoneTransaction(BankCard, transactionRequest.Money, transactionRequest.Target),
            _ => throw new NotImplementedException()
        };
        TransactionList.Add(transaction);
        return transaction;
    }
}
