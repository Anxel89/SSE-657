using System;
using System.Collections.Generic;
using System.Data.SQLite;
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
            Update_Transcation();
        }

        private void mainMenu1Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow dashboard = new MainWindow();
            dashboard.Show();
            this.Close();
        }

        private void Update_Transcation()
        {
            SQLiteConnection sqlCon = new SQLiteConnection("Data Source = MyDatabase.sqlite; Version=3;");
            try
            {
                if (sqlCon.State == System.Data.ConnectionState.Closed)
                    sqlCon.Open();

                string query = "SELECT * FROM tran";
                SQLiteCommand sqlCmd = new SQLiteCommand(query, sqlCon);
                SQLiteDataReader reader = sqlCmd.ExecuteReader();

                while (reader.Read())
                {
                    if (reader["Sender"].ToString() == "global")
                    {
                        buySoldListBox.Items.Add("+" + reader["Amount"].ToString() + " " + reader["Currency"].ToString());
                    }

                    else if(reader["Reciever"].ToString() == "global")
                    {
                        buySoldListBox.Items.Add("-" + reader["Amount"].ToString() + " " + reader["Currency"].ToString());
                    }
                    else
                    {
                        sentRecListBox.Items.Add(reader["Reciever"] + " " + reader["Amount"] + " " + reader["Currency"] + " " + reader["Description"]);
                    }
                }
                
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sqlCon.Close();

            }
        }
    }


 }

