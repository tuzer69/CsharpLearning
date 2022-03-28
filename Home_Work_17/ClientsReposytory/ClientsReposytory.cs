using System;
using System.Collections.Generic;
using UseCases.Interfeces;
using DB = Database.Database;

namespace ClientsReposytory
{
    using HomeWork.Entities;
    public class ClientsReposytory //: IReposytory<Client>
    {
        private readonly DB _database;

        public ClientsReposytory(DB database)
        {
            _database = database;
        }

        public void CreateClient(string firstName, string lastName)
        {
            _database.ClientsList.Add(new Client(firstName, lastName));
        }

        public void UpdateClient(string firstName, string lastName)
        {
            foreach (var client in _database.ClientsList)
            {
                if (client.Name == firstName && client.Surname == lastName)
                {
                    client.Name = firstName;
                    client.Surname = lastName;
                    break;
                }
            }
        }

        public void DeleteClient(string firstName, string lastName)
        {
            foreach (var client in _database.ClientsList)
            {
                if (client.Name == firstName && client.Surname == lastName)
                {
                    _database.ClientsList.Remove(client);
                    break;
                }
            }
        }

        public Client ReadClient(string firstName, string lastName)
        {
            foreach (var client in _database.ClientsList)
            {
                if (client.Name == firstName && client.Surname == lastName)
                {
                    return client;
                }

            }
            return null;
            
            

        }

        public List<Client> GetClients()
        {
            return _database.ClientsList;
        }

    }
}
