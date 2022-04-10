using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentServiceServer.Controllers
{
    internal class TieCardController
    {
        [Controller(CallbackCommand.TieBankCard)]
        public static TieBankCardStatusVievModel TieCard(PaymentServiceSessoin sessoin, string viewModel)
        {
            TieBankCardViewModel tieBankCard = ViewModel.Deserialize<TieBankCardViewModel>(viewModel);
            using Context context = new Context();
            Account? account = context.Accounts.SingleOrDefault(a => a.Id == sessoin.AccountId);
            if (account is null)
            {
                Console.WriteLine($"ERROR ACC {sessoin.AccountId}");
                return new TieBankCardStatusVievModel();
            }
            account.BankCard = new BankCard(tieBankCard);
            
            context.SaveChanges();

            return new TieBankCardStatusVievModel(account.BankCard.Number);
        }
    }
}
