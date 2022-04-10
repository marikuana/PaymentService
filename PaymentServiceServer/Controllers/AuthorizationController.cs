using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentServiceServer.Controllers
{
    internal class AuthorizationController
    {
        [Controller(CallbackCommand.Authorisation)]
        public static ViewModel Authorisation(PaymentServiceSessoin sessoin, string viewModel)
        {
            AuthorizationViewModel authorization = ViewModel.Deserialize<AuthorizationViewModel>(viewModel);
            using Context context = new Context();

            Account? account = context.Accounts
                .Include(a => a.BankCard)
                .Include(a => a.TransactionList).ThenInclude(t => t.BankCard)
                .AsNoTracking()
                .SingleOrDefault(a => a.Login == authorization.Login);
            if (account is null || account.Password != authorization.Password)
            {
                return null; // CallbackFactory.CreateError("Неправильний логін або пароль");
            }
            sessoin.SetAccountId(account.Id);
            
            var transactions = Mapper.Map<List<TransactionViewModel>>(account.TransactionList);
            var bankCard = Mapper.Map<BankCardViewModel>(account.BankCard);


            return new AuthorisationAccess(bankCard, transactions);
        }
    }
}
