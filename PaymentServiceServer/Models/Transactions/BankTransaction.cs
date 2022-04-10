public class BankTransaction : Transaction
{
    public BankTransaction(BankCard bankCard, float amountMoney, string target, string description = "Переказ на карту") : 
        base(bankCard, amountMoney, target, description)
    {
    }

    public BankTransaction() { }

    public override string Image =>
        "Bank";
}
