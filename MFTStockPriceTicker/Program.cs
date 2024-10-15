using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MFTStockPriceTicker.Models;
using Microsoft.AspNetCore.SignalR.Client;

namespace MFTStockPriceTicker
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var connection = new HubConnectionBuilder()
                .WithUrl("http://localhost:5262/stockPriceHub") 
                .Build();
            
            connection.On<List<StockPrice>>("ReceiveStockPrices", stockPrices =>
            {
                foreach (var stock in stockPrices)
                {
                    Console.WriteLine($"Stock: {stock.Name}, Price: {stock.Price}");
                }
            });

            await connection.StartAsync();
            Console.WriteLine("Connected to the stock price hub. Press any key to exit.");
            Console.ReadKey();
        }
    }
}