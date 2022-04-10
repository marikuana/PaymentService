public class TransactionViewModel : ViewModel
{
    public string Image { get; set; }
    public float Money { get; set; }
    public DateTime Date { get; set; }
    public string Description { get; set; }

    public TransactionViewModel(string image, float money, DateTime date, string description)
    {
        Image = image;
        Money = money;
        Date = date;
        Description = description;
    }

    public TransactionViewModel() { }
}

