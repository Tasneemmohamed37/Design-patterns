namespace SingletonPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Enter Base Currency: ");
                var baseCurrency = Console.ReadLine();

                Console.WriteLine("Enter Target Currency: ");
                var targetCurrency = Console.ReadLine();

                Console.WriteLine("Enter Amount: ");
                var amount = decimal.Parse(Console.ReadLine());

                //var converter = new CurrencyConverter();
                // Use the instance via ClassName.Instance
                var exchangeAmount = CurrencyConverter.Instance.Convert(baseCurrency, targetCurrency, amount);

                Console.WriteLine($"{amount} {baseCurrency} = {exchangeAmount} {targetCurrency}");
                Console.WriteLine("-----------------------------------------");
            }
        }
    }
}
