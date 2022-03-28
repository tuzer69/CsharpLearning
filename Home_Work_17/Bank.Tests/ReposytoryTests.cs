using NUnit.Framework;
using ClientDatabase = Database.Database;


namespace Bank.Tests
{
    using ClientsReposytory;

    [TestFixture]
    public class ReposytoryTests
    {
        
        [Test]
        public void Repository_AddClient_plus1Client()
        {
            var rep = new ClientsReposytory(new ClientDatabase());
            int expected = rep.GetClients().Count + 1;
            rep.CreateClient("Name1", "Name2");

            int actual = rep.GetClients().Count;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Repository_RemoveClient_minus1Client()
        {
            var rep = new ClientsReposytory(new ClientDatabase());
            int expected = rep.GetClients().Count;
            rep.CreateClient("Name1", "Surname1");
            rep.DeleteClient("Name1", "Surname1");

            int actual = rep.GetClients().Count;

            Assert.AreEqual(expected, actual);
        }

    }
}