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

namespace MoneyTransfer657
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void sendReqMenuButton_Click(object sender, RoutedEventArgs e)
        {
            Window1 dashboard = new Window1();
            dashboard.Show();
            this.Close();
        }

        private void transHistMenuButton_Click(object sender, RoutedEventArgs e)
        {
            TransHistPage dashboard = new TransHistPage();
            dashboard.Show();
            this.Close();
        }

        private void bankingMenuButton_Click(object sender, RoutedEventArgs e)
        {
            BankingPage dashboard = new BankingPage();
            dashboard.Show();
            this.Close();
        }

        private void investMenuButton_Click(object sender, RoutedEventArgs e)
        {
            InvestPage dashboard = new InvestPage();
            dashboard.Show();
            this.Close();
        }
    }
}
