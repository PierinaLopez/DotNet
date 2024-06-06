using Bank;

namespace BankTest
{
    [TestClass]
    public class AccountTest
    {
        [TestMethod]
        public void Constructor_Balance0_Returns0()
        {
            //ARRANGE
            Account account = new Account();
            //ACT
            double balance = account.Balance;
            //ASSERT
            Assert.AreEqual(0, balance);
        }

        [TestMethod]
        public void Credit_9990nBalance0_Return999()
        {
            //ARRANGE
            Account account = new Account();

            //ACT
            account.Credit(999);

            //ASSERT
            Assert.AreEqual(999, account.Balance);
        }
        [TestMethod]
        public void Debit_500FromBalance500_Return0()
        {
            //ARRANGE
            Account account = new Account();
            account.Credit(500);

            //ACT
            account.Debit(500);

            //ASSERT
            Assert.AreEqual(0, account.Balance);
        }

        [TestMethod]
        public void Credit_NegativeAmount_ReturnsOutOfRangeException()
        {
            //ARRANGE
            Account account = new Account();

            //ASSERT
            Assert.ThrowsException<ArgumentOutOfRangeException>(
                () => account.Credit(-200)//ACT
                );
        }

        public void Debit_AmountBiggerThanBalance_ThrowsBalanceInsufficientException()
        {
            Account account = new Account();
            account.Credit(400);

            Assert.ThrowsException<BalanceInsufficientException>(() => account.Debit(500));

        }


    }
}