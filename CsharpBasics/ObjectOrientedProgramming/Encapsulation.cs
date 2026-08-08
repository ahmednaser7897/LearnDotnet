namespace CsharpFundamentals.ObjectOrientedProgramming;

internal static class Encapsulation
{
    public static void Run()
    {
        Console.WriteLine("\n========== Encapsulation ==========");

        BankAccount account = new("ACC-1001", 500m);
        account.Deposit(200m);
        bool withdrawn = account.TryWithdraw(150m);

        Console.WriteLine($"Account: {account.AccountNumber}");
        Console.WriteLine($"Withdrawal succeeded: {withdrawn}");
        Console.WriteLine($"Balance: {account.Balance:C}");

        // This would not compile because callers cannot directly break the invariant:
        // account.Balance = -1_000_000m;
    }

    private sealed class BankAccount
    {
        // Private state is changed only through operations that preserve the object's rules.
        private decimal _balance;

        public BankAccount(string accountNumber, decimal openingBalance)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(accountNumber);
            ArgumentOutOfRangeException.ThrowIfNegative(openingBalance);

            AccountNumber = accountNumber;
            _balance = openingBalance;
        }

        // A get-only property exposes information without exposing mutation.
        public string AccountNumber { get; }

        // The public API can expose calculated or protected state safely.
        public decimal Balance => _balance;

        public void Deposit(decimal amount)
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(amount);
            _balance += amount;
        }

        public bool TryWithdraw(decimal amount)
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(amount);

            if (amount > _balance)
            {
                return false;
            }

            _balance -= amount;
            return true;
        }
    }
}
