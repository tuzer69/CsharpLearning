using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Annotations;
using HomeWork.Entities;
using NSubstitute;
using NUnit.Framework;

namespace Tests;

[TestFixture]
public class ClientModelTests
{
    [Test]
    public void client_add_simple_account()
    {
        // Arrange
        var client = Substitute.For<IClient>();

        // Act
        client.AddSimpleAccount();

        // Assert
        client.Received().AddSimpleAccount();
        
    }

    [Test]
    public void client_add_deposit_account()
    {
        // Arrange
        var client = Substitute.For<IClient>();

        // Act
        client.AddDepositAccount();

        // Assert
        client.Received().AddDepositAccount();

    }

    [Test]
    public void client_remove_account()
    {
        // Arrange
        var account = Substitute.For<IAccount>();
        var client = Substitute.For<IClient>();

        // Act
        client.RemoveAccount(account);

        // Assert
        client.Received().RemoveAccount(account);

    }

    [Test]
    public void client_get_accounts()
    {
        // Arrange
        var client = Substitute.For<IClient>();

        // Act
        client.GetAccounts();

        // Assert
        client.Received().GetAccounts();

    }
    
}