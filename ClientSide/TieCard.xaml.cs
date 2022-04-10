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
    /// Interaction logic for TieCard.xaml
    /// </summary>
    public partial class TieCard : Window
    {
        public TieCard()
        {
            InitializeComponent();

            for (int i = 1; i <= 12; i++)
            {
                Month.Items.Add(i);
            }

            for (int i = DateTime.Now.Year; i <= DateTime.Now.Year + 10; i++)
            {
                Year.Items.Add(i);
            }
            Month.SelectedIndex = 0;
            Year.SelectedIndex = 0;
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Number.Text.Length != 16 || Pin.Text.Length != 3)
            {
                MessageBox.Show("Заповніть всі поля", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            TieBankCardStatusVievModel vievModel = await App.PaymentServiceClient.SendCallback<TieBankCardStatusVievModel>(new Callback(CallbackCommand.TieBankCard, new TieBankCardViewModel(Number.Text, new DateTime(Convert.ToInt32(Year.Text), Convert.ToInt32(Month.Text), 1), Pin.Text)));

            Close();
            Client.BankCard = new BankCardViewModel() { Number = vievModel.BankCard };

            MessageBox.Show($"Ви успішно привязали карту {Client.BankCardNumber}", "Карта привязана", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
