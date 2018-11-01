﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace MoneyTransfer657
{
    class User
    {
        string username;
        decimal balance;
        decimal btc;
        decimal xrp;
        decimal eth;
        decimal usd;
        string id;
        public decimal Btc
        {
            get { return balance; }
            set { btc = value; }
        }
        public decimal Balance
        {
            get { return balance; }
        }
        public User()
        {

        }
        public User(string username)
        {
            this.username = username;
            Bal_Setup();

        }

        private void Bal_Setup()
        {
            SQLiteConnection sqlCon = new SQLiteConnection("Data Source = MyDatabase.sqlite; Version=3;");
            try
            {
                if (sqlCon.State == System.Data.ConnectionState.Closed)
                    sqlCon.Open();

                string query = "SELECT * FROM user WHERE Username='" + username + "'";
                SQLiteCommand sqlCmd = new SQLiteCommand(query, sqlCon);
                SQLiteDataReader reader = sqlCmd.ExecuteReader();
                while (reader.Read())
                {
                    id = reader["ID"].ToString();
                }

                string query2 = "SELECT * FROM wallet WHERE ID ='" + id + "'";
                SQLiteCommand sqlCmd2 = new SQLiteCommand(query2, sqlCon);
                SQLiteDataReader reader2 = sqlCmd2.ExecuteReader();
                while (reader2.Read())
                {
                    usd = Convert.ToDecimal(reader2["USD"]);
                    xrp = Convert.ToDecimal(reader2["XRP"]);
                    eth = Convert.ToDecimal(reader2["ETH"]);
                    btc = Convert.ToDecimal(reader2["BTC"]);
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
            Crypto BTC = new Crypto("BTC");
            Crypto XRP = new Crypto("XRP");
            Crypto ETH = new Crypto("ETH");
            balance = usd + (btc * BTC.Price) + (xrp * XRP.Price) + (eth * ETH.Price);
        }
        public void Sell_BTC(decimal value)
        {
            btc = btc - value;
            Crypto BTC = new Crypto("BTC");
            usd = usd + (BTC.Price * value);

        }
        public void Buy_BTC(decimal value)
        {
            btc = btc + value;
            Crypto BTC = new Crypto("BTC");
            usd = usd - (BTC.Price * value);
        }
        public void Sell_XRP(decimal value)
        {
            xrp = xrp - value;
            Crypto XRP = new Crypto("XRP");
            usd = usd + (XRP.Price * value);
        }

        public void Buy_XRP(decimal value)
        {
            xrp = xrp + value;
            Crypto XRP = new Crypto("XRP");
            usd = usd - (XRP.Price * value);
        }
        public void Sell_ETH(decimal value)
        {
            eth = eth - value;
            Crypto ETH = new Crypto("ETH");
            usd = usd + (ETH.Price * value);
        }

        public void Buy_ETH(decimal value)
        {
            eth = eth + value;
            Crypto ETH = new Crypto("ETH");
            usd = usd - (ETH.Price * value);
        }


        public void Update_Bal()
        {
            Crypto BTC = new Crypto("BTC");
            Crypto XRP = new Crypto("XRP");
            Crypto ETH = new Crypto("ETH");
            balance = usd + (btc * BTC.Price) + (xrp * XRP.Price) + (eth * ETH.Price);
        }
        public void Update_Database()
        {
            SQLiteConnection sqlCon = new SQLiteConnection("Data Source = MyDatabase.sqlite; Version=3;");
            try
            {
                if (sqlCon.State == System.Data.ConnectionState.Closed)
                    sqlCon.Open();

                string query = "UPDATE wallet SET USD ='" + usd + "', XRP ='" + xrp + "', BTC = '" + btc + "', ETH = '" + eth + "' WHERE ID = '" + id + "'";
                SQLiteCommand sqlCmd = new SQLiteCommand(query, sqlCon);
                sqlCmd.ExecuteNonQuery();

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

    }// end of class
}// end of namespace