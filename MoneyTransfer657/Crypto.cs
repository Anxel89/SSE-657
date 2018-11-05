﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Security.Cryptography;
using System.Net.Http;
using Binance.API.Csharp.Client;
using System.Threading;
using System.ComponentModel;

namespace MoneyTransfer657
{
    public class Crypto
    {
        long[] supply_arr = { 17299000, 39870907279, 102300268 };
        string name;
        decimal price;
        decimal volume;
        long circulating_supply;
        decimal market_cap;

        public string Name
        {
            get { return name; }
        }
        public decimal Price
        {
            get { return price; }
        }
        public decimal Volume
        {
            get { return volume; }
        }
        public long Supply
        {
            get { return circulating_supply; }
        }
        public decimal Market_Cap
        {
            get { return market_cap; }
        }


        public Crypto()
        {

        }
        public Crypto(string name)
        {
            this.name = name;
            Get_Price();
            Get_Volume();
            if (name == "BTC")
            {
                circulating_supply = supply_arr[0];
            }
            else if (name == "XRP")
            {
                circulating_supply = supply_arr[1];
            }
            else
            {
                circulating_supply = supply_arr[2];
            }
            market_cap = circulating_supply * price;

        }

        private void Get_Price()
        {

            var apiClient = new ApiClient("kqj7EeRsUcWxOsGuvVvtqyrV04ieCHKROQpjE3vyXgvVQEfKzcIKVMI4n89O4AKt", "79rvVk1A5rFyLnmTzoGQEXT8eiwHn9LgTpAmFmzNb0OcTGEw8XmxUoEjV33WQFON");
            var BinanceClient = new BinanceClient(apiClient);
            var priceChangeInfo = BinanceClient.GetAllPrices().Result;
            string price_to_get = name + "USD";
            for (int i = 0; i < priceChangeInfo.Count(); i++)
            {
                if (priceChangeInfo.ElementAt(i).Symbol.Contains(price_to_get))
                {
                    price = priceChangeInfo.ElementAt(i).Price;
                }
            }

        }

        private void Get_Volume()
        {
            var apiClient = new ApiClient("kqj7EeRsUcWxOsGuvVvtqyrV04ieCHKROQpjE3vyXgvVQEfKzcIKVMI4n89O4AKt", "79rvVk1A5rFyLnmTzoGQEXT8eiwHn9LgTpAmFmzNb0OcTGEw8XmxUoEjV33WQFON");
            var BinanceClient = new BinanceClient(apiClient);
            var priceChangeInfo = BinanceClient.GetPriceChange24H().Result;
            string price_to_get = name + "USD";
            for (int i = 0; i < priceChangeInfo.Count(); i++)
            {
                if (priceChangeInfo.ElementAt(i).Symbol.Contains(price_to_get))
                {
                    volume = price * priceChangeInfo.ElementAt(i).Volume;

                }
            }
        }

    }
}