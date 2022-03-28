using HomeWork13.Entities;
using NUnit.Framework;

namespace Bank.Tests
{
    [TestFixture]
    public class ReposytoryTests
    {
        [Test]
        public void Repository_AddClient_plus1Client()
        {
            var rep = new Repository<Client>();
            rep.AddClient("Name1", "Name2");
            int expected = 1;

            int actual = rep.ClientsList.Count;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Repository_RemoveClient_minus1Client()
        {
            var rep = new Repository<Client>();
            rep.AddClient("Name1", "Surname1");
            rep.RemoveClient("Name1", "Surname1");
            int expected = 0;

            int actual = rep.ClientsList.Count;

            Assert.AreEqual(expected, actual);
        }

    }
}