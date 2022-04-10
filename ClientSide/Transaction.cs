using System;

namespace ClientSide
{
    class Transaction
    {
        public Uri ImageUri { get => new Uri($"{System.IO.Directory.GetCurrentDirectory()}/Images/{Image}.png"); }
        public string Image { get; set; }
        public float Money { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }

        public Transaction(string image, float money, DateTime date, string description)
        {
            Image = image;
            Money = money;
            Date = date;
            Description = description;
        }

        public Transaction(TransactionViewModel transactionViewModel)
            : this(transactionViewModel.Image, transactionViewModel.Money, transactionViewModel.Date, transactionViewModel.Description)
        {

        }
    }
}
