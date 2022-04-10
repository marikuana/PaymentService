using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ClientSide
{
    /// <summary>
    /// Interaction logic for Authorization.xaml
    /// </summary>
    public partial class Authorization : Window
    {
        public Authorization()
        {
            InitializeComponent();

            Button_Click_ShowLogin(null, null);
        }

        public void Button_Click_ShowLogin(object sender, RoutedEventArgs e)
        {
            auth.Visibility = Visibility.Visible;
            reg.Visibility = Visibility.Hidden;

            authButt.FontWeight = FontWeights.Bold;
            regButt.FontWeight = FontWeights.Normal;
        }

        private void Button_Click_ShowRegistration(object sender, RoutedEventArgs e)
        {
            auth.Visibility = Visibility.Hidden;
            reg.Visibility = Visibility.Visible;

            authButt.FontWeight = FontWeights.Normal;
            regButt.FontWeight = FontWeights.Bold;
        }

        private async void Button_Click_Login(object sender, RoutedEventArgs e)
        {
            if (auth_log.Text.Length == 0 || auth_pas.Text.Length == 0) return;

            await AuthAsync(new AuthorizationViewModel(auth_log.Text, auth_pas.Text));
            MainWindow.GetMainWindow().Show();
            Close();
        }

        private Task AuthAsync(AuthorizationViewModel authorization)
        {
            return Task.Run(async () =>
            {
                AuthorisationAccess authorisationAccess = await App.PaymentServiceClient.SendCallback<AuthorisationAccess>(new Callback(CallbackCommand.Authorisation, authorization));
                Client.Login = authorization.Login;
                Client.BankCard = authorisationAccess.BankCardViewModel;
                Client.AddTransactions(authorisationAccess.TransactionList.Select(s => new Transaction(s)));
            });
        }

        private async void Button_Click_Registr(object sender, RoutedEventArgs e)
        {
            if (reg_log.Text.Length == 0 || reg_pas.Text.Length == 0) return;

            RegistrationStatusViewModel viewModel = await App.PaymentServiceClient.SendCallback<RegistrationStatusViewModel>(new Callback(CallbackCommand.Registration, new RegistrationViewModel(reg_log.Text, reg_pas.Text)));
            if (viewModel.Status == RegistrationStatus.Success)
            {
                NotifyFactory.Create(NotifyType.RegisterSuccess).Send();
                auth_log.Text = reg_log.Text;
                auth_pas.Text = reg_pas.Text;
                Button_Click_ShowLogin(sender, e);
            }
            else
            {
                NotifyFactory.Create(NotifyType.LoginBrooked).Send();
            }
        }
    }
}
