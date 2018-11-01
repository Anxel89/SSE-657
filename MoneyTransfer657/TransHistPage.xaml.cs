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
    /// Interaction logic for TransHistPage.xaml
    /// </summary>
    public partial class TransHistPage : Window
    {
        public TransHistPage()
        {
            InitializeComponent();
        }

        private void mainMenu1Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow dashboard = new MainWindow();
            dashboard.Show();
            this.Close();
        }

        private void sentRecSearchButton_Click(object sender, RoutedEventArgs e)
        {
          
            /*listBox1.ClearSelected();

            int index = listBox1.FindString(textBox1.Text);

            if (index < 0)
            {
                MessageBox.Show("Item not found.");
                textBox1.Text = String.Empty;
            }
            else
            {
                listBox1.SelectedIndex = index;
            }*/
        }

        private void TransEXData_Click(object sender, RoutedEventArgs e)
        {
            int a = 400, b=100;
            decimal aa = 1.0058965M, bb = 600.2546M;

            sentRecListBox.Items.Add("Erik Lomas                +" + a);
            sentRecListBox.Items.Add("John Smith                -" + b);

            buySoldListBox.Items.Add("BTC                       +" + aa);
            buySoldListBox.Items.Add("Ripple                    +" + bb);
        }
    }
}
