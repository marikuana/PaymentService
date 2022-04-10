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
using System.Net.Sockets;
using Newtonsoft.Json;
using System.Threading;
using ClientSide.Pages;

namespace ClientSide
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static MainWindow? mainWindow;
        public static MainWindow GetMainWindow()
        {
            if (mainWindow == null)
                mainWindow = new MainWindow();
            return mainWindow;
        }

        public static TieCard? TieCardWindow;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_Phone(object sender, RoutedEventArgs e)
        {
            Place.Content = new Phone();
            title.Text = ((Button)sender).Content.ToString();
        }

        private void Button_Click_History(object sender, RoutedEventArgs e)
        {
            Place.Content = new History();
            title.Text = ((Button)sender).Content.ToString();
        }

        private void Button_Click_TieCard(object sender, RoutedEventArgs e)
        {
            TieCardWindow = new TieCard();
            TieCardWindow.ShowDialog();
        }

        private void Button_Click_BankCard(object sender, RoutedEventArgs e)
        {
            Place.Content = new Pages.BankCard();
            title.Text = ((Button)sender).Content.ToString();
        }
    }
}
