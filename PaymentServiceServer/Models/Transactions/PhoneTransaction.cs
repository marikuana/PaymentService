public class PhoneTransaction : Transaction
{
    public PhoneTransaction(BankCard bankCard, float amountMoney, string target, string description = "Поповнення телефону") : 
        base(bankCard, amountMoney, target, description)
    {
    }

    public PhoneTransaction() { }

    public override string Image =>
        "Phone";
}
