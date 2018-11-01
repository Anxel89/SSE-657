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

namespace MoneyTransfer657
{
    /// <summary>
    /// Interaction logic for BankingPage.xaml
    /// </summary>
    public partial class BankingPage : Window
    {
        public BankingPage()
        {
            InitializeComponent();
        }

        private void bankingExampleButton_Click(object sender, RoutedEventArgs e)
        {
            int c = 1234;
            linkedAccountsListBox.Items.Add("BB&T Checking  ****" + c);
            
        }

        private void mainMenu2Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow dashboard = new MainWindow();
            dashboard.Show();
            this.Close();
        }
    }
}
