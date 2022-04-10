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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ClientSide.Pages
{
    /// <summary>
    /// Логика взаимодействия для Phone.xaml
    /// </summary>
    public partial class Phone : Page
    {
        public Phone()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Client.BankCard == null)
            {
                MessageBox.Show("Привяжіть карту", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            Money.Text = Money.Text.Replace(".", ",").Trim();
            Client.Transaction(PhoneNumber.Text, Convert.ToSingle(Money.Text), TransactionType.Phone);
        }
    }
}
