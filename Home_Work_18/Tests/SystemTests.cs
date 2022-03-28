using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DataAccess.Implementation;
using HomeWork.Entities;
using NUnit.Framework;
using UseCases.Commands;

namespace Tests
{
    [TestFixture]
    public class Tests
    {

        [Test]
        public async Task Add_SumpleAccount_ReturnListPlus1()
        {
            var client = new Client("Name1", "Surname1")
            {
                Accounts = new List<Account>()
            };
            var handler = new AddSimpleAccountCommand(new BankSystemContext());
            var command = new AddSimpleAccountCommand.Command
            {
                Client = client
            };
            var actual = client.Accounts.Count;

            await handler.Handle(command, new CancellationToken());
            var expected = client.Accounts.Count;

            Assert.AreEqual(expected, actual + 1);
        }

        [Test]
        public async Task Add_DepositAccount_ReturnListPlus1()
        {
            var client = new Client("Name1", "Surname1");
            client.Accounts = new List<Account>();
            var handler = new AddDepositAccountCommand(new BankSystemContext());
            var command = new AddDepositAccountCommand.Command
            {
                Client = client
            };
            var actual = client.Accounts.Count;

            await handler.Handle(command, new CancellationToken());
            var expected = client.Accounts.Count;

            Assert.AreEqual(expected, actual + 1);
        }

        [Test]
        public async Task AddBalance_ClientAccount_ReturnAddBalance()
        {
            var client = new Client("Name1", "Surname1");
            client.Accounts = new List<Account>();
            var handler = new AddDepositAccountCommand(new BankSystemContext());
            var command = new AddDepositAccountCommand.Command
            {
                Client = client
            };
            await handler.Handle(command, new CancellationToken());
            var actual = client.Accounts[0].Balance;
            var addBalanceHandler = new AddBalanceAccountCommand(new BankSystemContext());
            var addBalanceCommand = new AddBalanceAccountCommand.Command
            {
                Account = client.Accounts[0],
                Amount = 1499
            };

            client.Accounts[0] = await addBalanceHandler.Handle(
                addBalanceCommand, new CancellationToken());
            var expected = client.Accounts[0].Balance;
            
            Assert.AreEqual(expected, actual + 1499);
        }

    }
}