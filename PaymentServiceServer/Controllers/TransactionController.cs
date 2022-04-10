using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaymentServiceServer;

namespace PaymentServiceServer.Controllers
{
    internal class TransactionController
    {
        [Controller(CallbackCommand.Transaction)]
        public static TransactionViewModel Transaction(PaymentServiceSessoin sessoin, string viewModel)
        {
            TransactionRequestViewModel transactionRequest = ViewModel.Deserialize<TransactionRequestViewModel>(viewModel);
            using Context context = new Context();
            Account? account = context.Accounts
                .Include(a => a.BankCard)
                .Include(a => a.TransactionList)
                .SingleOrDefault(a => a.Id == sessoin.AccountId);

            if (account == null)
                return null; // CallbackFactory.CreateError("Аккаунт не знайдено");

            Transaction? transaction = account.Transaction(transactionRequest);
            if (transaction == null)
                return null;// CallbackFactory.CreateError("Помилка транзакції");

            var transactionVievModel = Mapper.Map<TransactionViewModel>(transaction);

            context.SaveChanges();
            return transactionVievModel;
        }
    }
}
