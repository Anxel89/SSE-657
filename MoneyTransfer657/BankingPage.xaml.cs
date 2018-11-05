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
            int i = 0;
            while(user.banking_accounts[i,0] != null)
            {
                linkedAccountsListBox.Items.Add(user.banking_accounts[i, 0] + " " + user.banking_accounts[i, 1]);
                Banking_ComboBox.Items.Add(user.banking_accounts[i, 0] + " " + user.banking_accounts[i, 1]);
                i++;
            }
            Usd_bal.Content = user.Usd.ToString("#,####.##");

        }        

        private void ReturnButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow dashboard = new MainWindow();
            dashboard.Show();
            this.Close();
        }
        private void TransfertoAppButton_Click(object sender, RoutedEventArgs e)
        {
            decimal transfer_amount;
            bool isNumeric = decimal.TryParse(transferamount.Text, out transfer_amount);
            if (isNumeric == false)
            {
                MessageBox.Show("Only enter numbers for amount to transfer");
                return;
            }
            Thread transfer = new Thread(() =>
            {
                user.Usd = user.Usd + transfer_amount;
                user.Update_Database();
            });
            transfer.Start();
            transfer.Join();
            UpdateBankingAccounts();


        }
        private void TransfertoBankButton_Click(object sender, RoutedEventArgs e)
        {
            decimal transfer_amount;
            bool isNumeric = decimal.TryParse(transferamount.Text, out transfer_amount);
            if (isNumeric == false)
            {
                MessageBox.Show("Only enter numbers for amount to transfer");
                return;
            }
            Thread transfer = new Thread(() =>
            {
                user.Usd = user.Usd - transfer_amount;
                user.Update_Database();
            });
            transfer.Start();
            transfer.Join();
            UpdateBankingAccounts();
        }
        private void LinkAccountButton_Click(object sender, RoutedEventArgs e)
        {
            int i = 0;
            while(true) {
                if (user.banking_accounts[i, 0] == null)
                {
                    
                    int transfer_amount;
                    bool isNumeric = int.TryParse(bankaccount_number.Text, out transfer_amount);
                    if (isNumeric == false)
                    {
                        MessageBox.Show("Only enter numbers for bank account number");
                        return;
                    }
                   
                 
                    user.banking_accounts[i, 0] = accounttextbox.Text;
                    user.banking_accounts[i, 1] = bankaccount_number.Text;
                    user.Add_Bank_Account_to_DB(accounttextbox.Text, bankaccount_number.Text);
                    user.Update_Database();                    
                    UpdateBankingAccounts();
                    break;
                    
                    
                    
                }
                i++;
            }
            
        }

        private void UpdateBankingAccounts()
        {
            linkedAccountsListBox.Items.Clear();
            Banking_ComboBox.Items.Clear();
            int i = 0;
            while (user.banking_accounts[i, 0] != null)
            {
                linkedAccountsListBox.Items.Add(user.banking_accounts[i, 0] + " " + user.banking_accounts[i, 1]);                
                Banking_ComboBox.Items.Add(user.banking_accounts[i, 0] + " " + user.banking_accounts[i, 1]);
                i++;
            }
            Usd_bal.Content = user.Usd.ToString("#,####.##");
        }

    }
}
