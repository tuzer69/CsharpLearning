using HomeWork.Entities;
using HomeWork.Wrappers;
using NUnit.Framework;

namespace Bank.Tests.WrappersTests
{
    [TestFixture]
    public class AccountWrapperTests
    {
        [Test]
        public void Account_AddBalanceSumpleAcc_plus5000()
        {
            var test = new AccountWrapper(new SimpleAccount());
            test.AddBalance(5000);
            long expected = 5000;

            long actual = test.Balance;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Account_TransferBalanceSumpleAcc_minus5000()
        {
            var test1 = new AccountWrapper(new SimpleAccount());
            IAccount test2 = new AccountWrapper(new SimpleAccount());
            test1.AddBalance(5000);
            test1.BalanceTransfer(test2, 5000);
            long expected = 0;

            long actual = 0;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Account_TransferBalanceSumpleAcc_Plus5000()
        {
            var test1 = new AccountWrapper(new SimpleAccount());
            IAccount test2 = new AccountWrapper(new SimpleAccount());
            test1.AddBalance(5000);
            test1.BalanceTransfer(test2, 5000);
            long expected = 5000;

            long actual = test2.Balance;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Account_ExternalTransferBalanceSumpleAcc_minus5000()
        {
            var test1 = new AccountWrapper(new SimpleAccount());
            IAccount test2 = new AccountWrapper(new SimpleAccount());
            test1.AddBalance(5000);
            test1.ExternalTransfer(test2, 5000);
            long expected = 0;

            long actual = 0;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Account_ExternalBalanceSumpleAcc_Plus5000()
        {
            var test1 = new AccountWrapper(new SimpleAccount());
            IAccount test2 = new AccountWrapper(new SimpleAccount());
            test1.AddBalance(5000);
            test1.ExternalTransfer(test2, 5000);
            long expected = 5000;

            long actual = test2.Balance;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Account_IsDeposit_returnFalse()
        {
            var test = new AccountWrapper(new SimpleAccount());

            bool actual = test.IsDeposit;

            Assert.False(actual);
        }

        [Test]
        public void Account_IsDeposit_returnTrue()
        {
            var test = new AccountWrapper(new DepositAccount());

            bool actual = test.IsDeposit;

            Assert.True(actual);
        }

        [Test]
        public void Account_SimpleAccountNumber_NotEquvalent()
        {
            var test1 = new AccountWrapper(new SimpleAccount());
            var test2 = new AccountWrapper(new SimpleAccount());
            var expected = test1.AccountNumber;

            var actual = test2.AccountNumber;

            Assert.AreNotEqual(expected, actual);

        }

        [Test]
        public void Account_DepositAccountNumber_NotEquvalent()
        {
            var test1 = new AccountWrapper(new DepositAccount());
            var test2 = new AccountWrapper(new DepositAccount());
            var expected = test1.AccountNumber;

            var actual = test2.AccountNumber;

            Assert.AreNotEqual(expected, actual);

        }

    }
}