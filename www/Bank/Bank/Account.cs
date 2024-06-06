namespace Bank
{

    public class BalanceInsufficientException : ApplicationException
    {
        public BalanceInsufficientException() { }
        public BalanceInsufficientException(string message) : base(message) { }

    }
    public class Account
    {
        private double balance = 0;

        public void Credit(double amount)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount));
            }
            balance += amount;
        }

        public void Debit(Double amount)
        {
            if (balance >= amount)
            {
                balance -= amount;
            }
            else
            {
                throw new BalanceInsufficientException("Insufficient balance. ");
            }
        }
        public double Balance
        {
            get { return balance; }
        }
    }
}
