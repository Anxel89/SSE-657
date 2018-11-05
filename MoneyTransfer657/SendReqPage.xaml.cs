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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        User user;
        public Window1()
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
            UpdatePage();
        }

        private void ReturnButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow dashboard = new MainWindow();
            dashboard.Show();
            this.Close();
        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            decimal amount_to_send;
            bool isNumeric = decimal.TryParse(AmountBox.Text, out amount_to_send);
            if (isNumeric == false)
            {
                MessageBox.Show("Only enter numbers for amount of currency to send");
                return;
            }
            if(CoinBox.SelectedIndex == 0)
            {
                user.Usd = user.Usd - amount_to_send;
                user.Add_Transaction(user.Username, RecipientText.Text, "USD", amount_to_send.ToString(), descrip_box.Text);
            }
            else if(CoinBox.SelectedIndex == 1)
            {
                user.Btc = user.Btc - amount_to_send;
                user.Add_Transaction(user.Username, RecipientText.Text, "BTC", amount_to_send.ToString(), descrip_box.Text);
            }
            else if(CoinBox.SelectedIndex == 2)
            {
                user.Eth = user.Eth - amount_to_send;
                user.Add_Transaction(user.Username, RecipientText.Text, "ETH", amount_to_send.ToString(), descrip_box.Text);
            }
            else if(CoinBox.SelectedIndex == 3)
            {
                user.Xrp = user.Xrp - amount_to_send;
                user.Add_Transaction(user.Username, RecipientText.Text, "XRP", amount_to_send.ToString(), descrip_box.Text);
            }
            else
            {
                MessageBox.Show("Please select a currency before sending.");
                return;
            }
            UpdatePage();
            user.Update_Database();
            
        }

        private void UpdatePage()
        {         
            usd_bal.Content = user.Usd.ToString("#,####.##");
            btc_bal.Content = user.Btc.ToString("#,####.##");
            eth_bal.Content = user.Eth.ToString("#,####.##");
            xrp_bal.Content = user.Xrp.ToString("#,####.##");
        }

       
    }
}
