namespace CsharpFundamentals.ObjectOrientedProgramming
{
    internal class IDisposapleDesignPattern
    {
        public static void Run()
        {
            Console.WriteLine("================== IDisposaple Design Pattern ==================");


            // 1) not recommended
            //CurrencyService currencyService = new CurrencyService();
            //var result = currencyService.GetCurrencies();
            //currencyService.Dispose();
            //Console.WriteLine(result);

            //2) recommended
            //CurrencyService currencyService = null;
            //try
            //{
            //    currencyService = new CurrencyService();
            //    var result = currencyService.GetCurrencies();
            //    Console.WriteLine(result);

            //}
            //catch (Exception)
            //{
            //    Console.WriteLine("Error");
            //}
            //finally
            //{
            //    currencyService?.Dispose(); 
            //}

            // 3) more recommended  using .net framework 2+
            // using compiles to try/finally and calls Dispose even if an exception occurs.
            //using (CurrencyService currencyService = new CurrencyService())
            //{ 
            //    var result = currencyService.GetCurrencies();
            //    Console.WriteLine(result);
            //}

            // 4) using with no blocks c# 8.0
            // A using declaration disposes the object at the end of the current scope.
            using CurrencyService currencyService = new CurrencyService();
            var result = currencyService.GetCurrencies();
            Console.WriteLine(result);
            AsyncDisposalExample().GetAwaiter().GetResult();
            Console.ReadKey();

            // The garbage collector manages memory, but Dispose manages scarce external resources promptly.
            // Never call GC.Collect in normal application code to solve resource ownership problems.
            Console.WriteLine("====================================\n\n\n");
        }
        static async Task AsyncDisposalExample()
        {
            // await using calls DisposeAsync when the scope ends.
            await using AsyncDemoResource resource = new();
            await Task.Yield();
        }
    }
    class CurrencyService : IDisposable
    {
        private readonly HttpClient httpClient;
        private bool _disposed = false;
        public CurrencyService()
        {
            httpClient = new HttpClient();
        }
        // The finalizer is a safety net for directly owned unmanaged memory, not normal cleanup logic.
        // A finalizer is only appropriate when directly owning an unmanaged resource.
        // Prefer SafeHandle instead of writing a finalizer in most application code.
        ~CurrencyService()
        {
            Dispose(false);
        }

        // disposing : true (dispose managed + unmanaged)      
        // disposing : false (dispose unmanaged + large fields)
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            // Dispose Logic
            if (disposing)
            {
                // dispose managed resouces
                httpClient.Dispose();
            }
            // unmanaged object
            // set large fields to null
            _disposed = true;

        }

        public void Dispose()
        {
            // dipose() is called 100%
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public string GetCurrencies()
        {
            string url = "https://dummyjson.com/todos";
            var result = httpClient.GetStringAsync(url).Result;
            return result;
        }
    }
    // Use IAsyncDisposable when cleanup itself requires asynchronous I/O.
    sealed class AsyncDemoResource : IAsyncDisposable
    {
        public async ValueTask DisposeAsync()
        {
            await Task.Yield();
            Console.WriteLine("Asynchronous cleanup completed.");
        }
    }
}