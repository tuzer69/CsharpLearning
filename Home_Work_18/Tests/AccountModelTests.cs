using HomeWork.Entities;
using NSubstitute;
using NUnit.Framework;

namespace Tests;

[TestFixture]
public class AccountModelTests
{
    [Test]
    public void add_balance_5000()
    {
        // Arrange
        var account = Substitute.For<IAccount>();
        // Act
        account.AddBalance(5000);
        // Assert
        account.Received().AddBalance(5000);
    }

    [Test]
    public void make_balanceTransfer()
    {
        // Arrange
        var sender = Substitute.For<IAccount>();
        var reciever = Substitute.For<IAccount>();
        // Act
        sender.BalanceTransfer(reciever, 999);
        // Assert
        sender.Received().BalanceTransfer(reciever, 999);
    }

    [Test]
    public void make_externalTransfer()
    {
        // Arrange
        var sender = Substitute.For<IAccount>();
        var reciever = Substitute.For<IAccount>();
        // Act
        sender.ExternalTransfer(reciever, 999);
        // Assert
        sender.Received().ExternalTransfer(reciever, 999);
    }

    [Test]
    public void check_account_balance()
    {
        // Arrange
        var account = Substitute.For<IAccount>();
        // Act
        account.Balance = 9999;
        // Assert
        account.Received().Balance = 9999;
    }
}