using AccountTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestAccountUnit
{
    [TestClass]
    public class UnitTest1
    {
        private double epsilon = 1e-6;
        [TestMethod]
        public void AccountCannotHaveNegativeOverdraftLimit()
        {
            Account account = new Account(-20);
            Assert.AreEqual(0, account.OverdraftLimit, epsilon);
        }

        [TestMethod]
       //The Deposit methods will not accept negative numbers.
        public void DepositDoesNotAcceptNegativeValue()
        {
            Account account = new Account(20);
            bool result = account.Deposit(-10);
            Assert.AreEqual(0, account.GetBalance(), epsilon);
            Assert.IsFalse(result);
        }
        [TestMethod]
        //The WithDraw methods will not accept negative numbers.
        public void WithDrawDoesNotAcceptNegativeValue()
        {
            Account account = new Account(20);
            bool result = account.Withdraw(-10);
            Assert.AreEqual(0, account.GetBalance(), epsilon);
            Assert.IsFalse(result);
        }

        //  Account cannot overstep its overdraft limit.
        [TestMethod]
        public void AccountCanNotOverStepOverDraftLimit()
        {
            Account account = new Account(20);
            bool result = account.Withdraw(70);
            Assert.AreEqual(0, account.GetBalance(), epsilon);
            Assert.IsFalse(result);
        }

        [TestMethod]
        // The Deposit and Withdraw methods will deposit or withdraw the correct amount, respectively.
        public void DepositPositiveValueOk()
        {
            Account account = new Account(20);
            bool result = account.Deposit(10);
            Assert.AreEqual(10, account.GetBalance(), epsilon);
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void WithDrawPositiveValueOverDraftOk()
        {
            Account account = new Account(20);
            bool result = account.Withdraw(10);
            Assert.AreEqual(-10, account.GetBalance(), epsilon);
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void WithDrawPositiveValueBalanceOk()
        {
            Account account = new Account(0);
            account.Deposit(30);
            bool result = account.Withdraw(10);
            Assert.AreEqual(20, account.GetBalance(), epsilon);
            Assert.IsTrue(result);
        }


    }
}
