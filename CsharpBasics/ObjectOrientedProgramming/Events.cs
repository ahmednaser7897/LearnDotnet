using System;
using System.Collections.Generic;
using System.Text;

namespace CsharpFundamentals.ObjectOrientedProgramming
{
    internal class Events
    {
        public static void Run()
        {
            Stock stock = new Stock("Amazon");

            stock.Price = 100;

            Console.WriteLine(stock.Name);
            Console.WriteLine(stock.Price);

            // Subscribe to the event.
            // This means: when the price changes, call Stock_onPriceChanged.
            stock.OnPriceChanged += Stock_onPriceChanged;

            stock.ChangePriceByPercent(0.05m);
            stock.ChangePriceByPercent(-0.05m);
            stock.ChangePriceByPercent(0.0m);
        }

        // This method will be called automatically when the event is raised.
        private static void Stock_onPriceChanged(Stock stock, decimal oldPrice)
        {
            if (stock.Price > oldPrice)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"New Stock Price is {stock.Price}");
            }
            else if (stock.Price < oldPrice)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"New Stock Price is {stock.Price}");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine($"Stock Price is {stock.Price}");
            }
        }
    }

    // Delegate defines the signature of methods that can subscribe to the event.
    public delegate void StockPriceChangeHandeler(Stock stock, decimal oldPrice);

    public class Stock
    {
        private string name;

        public string Name
        {
            get { return name; }
        }

        public decimal Price { get; set; }

        public Stock(string name)
        {
            this.name = name;
        }

        // Event based on the StockPriceChangeHandeler delegate.
        // Other classes can subscribe using += and unsubscribe using -=.
        public event StockPriceChangeHandeler OnPriceChanged;

        public void ChangePriceByPercent(decimal percent)
        {
            // Save the old price before changing it.
            decimal oldestPrice = Price;

            // Change the stock price.
            Price = Math.Round(Price + Price * percent, 2);

            // Raise/Fire the event if there are subscribers.
            // This calls all methods subscribed to onPriceChanged.
            if (OnPriceChanged != null)
            {
                OnPriceChanged(this, oldestPrice);
            }
        }
    }
}