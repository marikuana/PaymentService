using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json;

namespace ClientSide
{
    static class Client
    {
        public static string Login { set; get; } = "User";
        public static string BankCardNumber { get => BankCard?.Number ?? "Карта не привязана"; }
        public static BankCardViewModel? BankCard { get; set; }

        public static List<Transaction> Transactions = new List<Transaction>()
        {
            new Transaction("Phone", 123, DateTime.Now.AddDays(-2), "Desc"),
            new Transaction("Bank", 321, DateTime.Now, "De")
        };

        public static async void Transaction(string target, float money, TransactionType transactionType)
        {
            TransactionViewModel viewModel = await App.PaymentServiceClient.SendCallback<TransactionViewModel>(new Callback(CallbackCommand.Transaction, new TransactionRequestViewModel(target, money, transactionType)));

            AddTransaction(new Transaction(viewModel));
            MessageBox.Show("Ви успішно перевели кошти", "Успішно", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public static void AddTransaction(Transaction transaction)
        {
            Transactions.Add(transaction);
        }

        public static void AddTransactions(IEnumerable<Transaction> transactions)
        {
            Transactions.AddRange(transactions);
        }
    }
}
