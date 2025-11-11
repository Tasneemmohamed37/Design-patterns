using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonPattern
{
    public class CurrencyConverter
    {
        private IEnumerable<ExchangeRate> _exchangeRates;


        // 1. private ctor
        private CurrencyConverter()
        {
            LoadExchangeRates();
        }

        // to prevent multi threading 
        private static object _lock = new();

        // 2. private static var same class dt
        private static CurrencyConverter _instance;

        // 3. public static property that returns the instance which we call ouside the class to create obj
        public static CurrencyConverter Instance
        {
            get 
            {
                // double-check locking
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                            _instance = new CurrencyConverter();
                    }
                }

                return _instance;
            }
        }


        private void LoadExchangeRates()
        {
            Thread.Sleep(3000); // waiting for 3 seconds to simulate heavy work

            _exchangeRates = new[]
            {
                new ExchangeRate ("USD","SAR", 4.6m),
                new ExchangeRate ("USD","EGP", 46.6m),
                new ExchangeRate ("SAR","EGP", 12.6m)

            };
        }

        public decimal Convert(string baseCurrency, string targetCurrency, decimal amount)
        {
            var exchangeRate = _exchangeRates.FirstOrDefault(r => r.BaseCurrency == baseCurrency && r.TargetCurrency == targetCurrency);
            return amount * exchangeRate.Rate; 

        }
    }
}
