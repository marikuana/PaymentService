using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentServiceServer.Controllers
{
    internal class RegisterController
    {
        [Controller(CallbackCommand.Registration)]
        public static RegistrationStatusViewModel Registration(PaymentServiceSessoin sessoin, string viewModel)
        {
            RegistrationViewModel registration = ViewModel.Deserialize<RegistrationViewModel>(viewModel);
            using Context context = new Context();
            Account? account = context.Accounts.SingleOrDefault(a => a.Login == registration.Login);
            if (account is not null)
            {
                Console.WriteLine($"Login {registration.Login} booked");
                return new RegistrationStatusViewModel(RegistrationStatus.Error); // new MessageViewModel(MessagesType.LoginBrooked);
            }
            context.Accounts.Add(new Account(registration));
            context.SaveChanges();
            return new RegistrationStatusViewModel(RegistrationStatus.Success);
        }
    }
}
