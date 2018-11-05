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
        private decimal xrp_price;
        private decimal eth_price;
        private decimal btc_price;
        private User user;
        public InvestPage()
        {
            InitializeComponent();
            Update_Page();
            Update_Owned();
        }

        private void ReturnButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow dashboard = new MainWindow();
            dashboard.Show();
            user.Update_Database();
            this.Close();
        }
        //done
        private void BuyCoinButton_Click(object sender, RoutedEventArgs e)
        {
            decimal amount_to_buy;
            bool isNumeric = decimal.TryParse(coinBuySellAmountTextBox.Text, out amount_to_buy);
            if (isNumeric == false)
            {
                MessageBox.Show("Only enter numbers for amount of coins to buy/sell");
                return;
            }
            if (selectCoinComboBox.SelectedIndex == 0)
            {
                //BTC
                if((amount_to_buy * btc_price) > user.Usd)
                {
                    MessageBox.Show("You dont have enough USD to make this purchase");
                    return;
                }
                Thread buy = new Thread(() =>
                {
                    user.Buy_BTC(amount_to_buy);
                });
                buy.Start();
                buy.Join();
                

            }
            else if (selectCoinComboBox.SelectedIndex == 1)
            {
                //ETH
                if ((amount_to_buy * eth_price) > user.Usd)
                {
                    MessageBox.Show("You dont have enough USD to make this purchase");
                    return;
                }
                Thread buy = new Thread(() =>
                {
                    user.Buy_ETH(amount_to_buy);

                });
                buy.Start();
                buy.Join();
                
            }
            else if (selectCoinComboBox.SelectedIndex == 2)
            {
                //XRP
                if ((amount_to_buy * xrp_price) > user.Usd)
                {
                    MessageBox.Show("You dont have enough USD to make this purchase");
                    return;
                }
                Thread buy = new Thread(() =>
                {
                    user.Buy_XRP(amount_to_buy);
                });
                buy.Start();
                buy.Join();
                
            }
            else
            {
                MessageBox.Show("Please select a coin before buying or selling.");
            }

            Update_Owned();
            MessageBox.Show("Purchase Complete");
        }

        private void SellCoinButton_Click(object sender, RoutedEventArgs e)
        {
            decimal amount_to_sell;
            bool isNumeric = decimal.TryParse(coinBuySellAmountTextBox.Text, out amount_to_sell);
            if (isNumeric == false)
            {
                MessageBox.Show("Only enter numbers for amount of coins to buy/sell");
                return;
            }
            if (selectCoinComboBox.SelectedIndex == 0)
            {
                if (amount_to_sell > user.Btc)
                {
                    MessageBox.Show("You dont have that much BTC to sell");
                    return;
                }
                Thread sell = new Thread(() =>
                {
                    user.Sell_BTC(amount_to_sell);
                });
                sell.Start();
                sell.Join();
                
            }
            else if (selectCoinComboBox.SelectedIndex == 1)
            {
                if (amount_to_sell > user.Eth)
                {
                    MessageBox.Show("You dont have that much ETH to sell");
                    return;         
                }
                Thread sell = new Thread(() =>
                {
                    user.Sell_ETH(amount_to_sell);
                });
                sell.Start();
                sell.Join();
            }
            else if (selectCoinComboBox.SelectedIndex == 2)
            {
                if (amount_to_sell > user.Xrp)
                {
                    MessageBox.Show("You dont have that much XRP to sell");
                    return;
                }
                Thread sell = new Thread(() =>
                {
                    user.Sell_XRP(amount_to_sell);
                });
                sell.Start();
                sell.Join();
            }
            else
            {
                MessageBox.Show("Please select a coin before buying or selling.");
            }
            Update_Owned();
            MessageBox.Show("Sale Complete");
        }

        private void Update_Page()
        {
            User EL = new User();
            Thread td_el = new Thread(() =>
            {
                EL = new User("Erik Lomas");
            });
            td_el.Start();
            td_el.Join();
            user = EL;
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
            Usd_bal.Content = user.Usd.ToString("#,####.##");
            btcPriceLabel.Content = btc.Price.ToString("#,####.##");
            btc_price = btc.Price;
            xrpPriceLabel.Content = xrp.Price.ToString("#,####.##");
            xrp_price = xrp.Price;
            ethPriceLabel.Content = eth.Price.ToString("#,####.##");
            eth_price = eth.Price;
            MarketCapBTC.Content = btc.Market_Cap.ToString("#,####.##");
            MarketCapETH.Content = eth.Market_Cap.ToString("#,####.##");
            MarketCapXRP.Content = xrp.Market_Cap.ToString("#,####.##");
            VolumeBTC.Content = btc.Volume.ToString("#,####.##");
            VolumeETH.Content = eth.Volume.ToString("#,####.##");
            VolumeXRP.Content = xrp.Volume.ToString("#,####.##");
        }

        private void Update_Owned()
        {
        
            btcOwned.Content = user.Btc;
            ethOwned.Content = user.Eth;
            xrpOwned.Content = user.Xrp;
            Usd_bal.Content = user.Usd.ToString("#,####.##");
            Thread update = new Thread(() =>
            {
                user.Update_Database();
            });
            update.Start();
            update.Join();

        }
        
    }
}
