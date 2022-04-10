using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class AuthorisationAccess : ViewModel
{
    public BankCardViewModel? BankCardViewModel { get; set; }
    public List<TransactionViewModel> TransactionList { get; set; }

    public AuthorisationAccess(BankCardViewModel? bankCardViewModel, List<TransactionViewModel> transactionList)
    {
        BankCardViewModel = bankCardViewModel;
        TransactionList = transactionList;
    }
}
