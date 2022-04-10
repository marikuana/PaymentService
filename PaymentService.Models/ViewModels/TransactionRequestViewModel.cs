public class TransactionRequestViewModel : ViewModel
{
    public string Target { get; set; }
    public float Money { get; set; }
    public TransactionType TransactionType { get; set; }

    public TransactionRequestViewModel(string target, float money, TransactionType transactionType)
    {
        Target = target;
        Money = money;
        TransactionType = transactionType;
    }
}

