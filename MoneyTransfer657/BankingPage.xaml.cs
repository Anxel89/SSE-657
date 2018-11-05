using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MoneyTransfer657
{
    /// <summary>
    /// Interaction logic for BankingPage.xaml
    /// </summary>
    public partial class BankingPage : Window
    {
        User user;
        public BankingPage()
        {
            InitializeComponent();
            User EL = new User();
            Thread td_el = new Thread(() =>
            {
                EL = new User("Erik Lomas");
            });
            td_el.Start();
            td_el.Join();
            user = EL;
            linkedAccountsListBox.Items.Add(user.banking_accounts[0, 0] + " " + user.banking_accounts[0, 1]);
        }

        private void bankingExampleButton_Click(object sender, RoutedEventArgs e)
        {
            int c = 1234;
            linkedAccountsListBox.Items.Add("BB&T Checking  ***" + c);
            
        }

        private void mainMenu2Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow dashboard = new MainWindow();
            dashboard.Show();
            this.Close();
        }
        private void TransfertoAppButton_Click(object sender, RoutedEventArgs e)
        {

        }
        private void TransfertoBankButton_Click(object sender, RoutedEventArgs e)
        {

        }
        private void LinkAccountButton_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}
