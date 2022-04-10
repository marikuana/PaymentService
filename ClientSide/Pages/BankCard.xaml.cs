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
    /// Логика взаимодействия для BankCard.xaml
    /// </summary>
    public partial class BankCard : Page
    {
        public BankCard()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Number.Text.Length != 16 || Money.Text.Length < 2) return;

            Client.Transaction(Number.Text, Convert.ToSingle(Money.Text), TransactionType.BankCard);
        }
    }
}
