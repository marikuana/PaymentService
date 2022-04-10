public class TieBankCardStatusVievModel : ViewModel
{
    public TieBankCardStatus Status { get => string.IsNullOrEmpty(BankCard) ? TieBankCardStatus.Error : TieBankCardStatus.Success; }
    public string BankCard { get; set; }

    public TieBankCardStatusVievModel(string bankCard = "")
    {
        BankCard = bankCard;
    }
}
