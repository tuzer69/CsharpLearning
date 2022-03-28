using System;
using HomeWork13.Entities;
using HomeWork13.Wrappers;
using NUnit.Framework;

namespace Bank.Tests.WrappersTests
{
    [TestFixture]
    public class ClientWrapperTests
    {
        [Test]
        public void Client_AddSimpleAccount_AccPlus1()
        {
            var client = new ClientWrapper(
                new Client("Name1", "Surname1"));
            int expected = 1;

            client.AddSimpleAccount();
            int actual = client.GetAccounts().Count;

            Assert.AreEqual(expected, actual);

        }

        [Test]
        public void Client_AddDepositAccount_AccPlus1()
        {
            var client = new ClientWrapper(
                new Client("Name1", "Surname1"));
            int expected = 1;

            client.AddDepositAccount();
            int actual = client.GetAccounts().Count;

            Assert.AreEqual(expected, actual);

        }

        [Test]
        public void Client_AddSimpleAccount_AccPlus10()
        {
            var client = new ClientWrapper(new Client("Name1", "Surname1"));
            for (int i = 0; i < 10; i++)
            {
                client.AddSimpleAccount();
            }
            int expected = 10;

            int actual = client.GetAccounts().Count;

            Assert.AreEqual(expected, actual);

        }

        [Test]
        public void Client_AddDepositAccount_AccPlus10()
        {
            var client = new ClientWrapper(new Client("Name1", "Surname1"));
            for (int i = 0; i < 10; i++)
            {
                client.AddDepositAccount();
            }
            int expected = 10;

            int actual = client.GetAccounts().Count;

            Assert.AreEqual(expected, actual);

        }

        [Test]
        public void Client_RemoveAccount_AccMinus1()
        {
            var client = new ClientWrapper(new Client("Name1", "Surname1"));
            for (int i = 0; i < 10; i++)
            {
                client.AddDepositAccount();
            }
            IAccount forRemove = client.GetAccounts()[0];
            client.RemoveAccount(forRemove);
            int expected = 9;

            int actual = client.GetAccounts().Count;

            Assert.AreEqual(expected, actual);

        }

        [Test]
        public void Client_RemoveAccount_AccMinus5()
        {
            var client = new ClientWrapper(new Client("Name1", "Surname1"));
            for (int i = 0; i < 10; i++)
            {
                client.AddDepositAccount();
            }

            for (int i = 0; i < 5; i++)
            {
                IAccount forRemove = client.GetAccounts()[i];
                client.RemoveAccount(forRemove);
            }

            int expected = 5;

            int actual = client.GetAccounts().Count;

            Assert.AreEqual(expected, actual);

        }

    }
}