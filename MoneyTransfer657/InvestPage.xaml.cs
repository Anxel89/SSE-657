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
using System.Threading;

namespace MoneyTransfer657
{
    /// <summary>
    /// Interaction logic for InvestPage.xaml
    /// </summary>
    public partial class InvestPage : Window
    {        
        public InvestPage()
        {
            InitializeComponent();
            update_from_api();


        }

        private void main3MenuButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow dashboard = new MainWindow();
            dashboard.Show();
            this.Close();
        }

        private void update_from_api()
        {
            Crypto btc = new Crypto();
            Thread td_btc = new Thread(() => {
                btc = new Crypto("BTC");
            });
            td_btc.Start();
            td_btc.Join();
            Crypto xrp = new Crypto();
            Thread td_xrp = new Thread(() => {
                xrp = new Crypto("XRP");
            });
            td_xrp.Start();
            td_xrp.Join();
            Crypto eth = new Crypto();
            Thread td_eth = new Thread(() => {
                eth = new Crypto("ETH");
            });
            td_eth.Start();
            td_eth.Join();
            btcPriceLabel.Content = btc.Price.ToString("#,####.##");
            xrpPriceLabel.Content = xrp.Price.ToString("#,####.##");
            ethPriceLabel.Content = eth.Price.ToString("#,####.##");
            MarketCapBTC.Content = btc.Market_Cap.ToString("#,####.##");
            MarketCapETH.Content = eth.Market_Cap.ToString("#,####.##");
            MarketCapXRP.Content = xrp.Market_Cap.ToString("#,####.##");
            VolumeBTC.Content = btc.Volume.ToString("#,####.##");
            VolumeETH.Content = eth.Volume.ToString("#,####.##");
            VolumeXRP.Content = xrp.Volume.ToString("#,####.##");
        }

        // public void update_owned_currency
        // {
//        User EL = new User();
//        Thread td_el = new Thread(() => {
//            EL = new User("Erik Lomas");
//        });
//        td_el.Start();
//        td_el.Join();
//       // }
}
}
