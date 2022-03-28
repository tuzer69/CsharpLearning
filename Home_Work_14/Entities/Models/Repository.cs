using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace HomeWork13.Entities
{
    public class Repository<TClient> : IRepository where TClient : Client, new()

    {
        public Repository()
        {
            ClientsList = new List<Client>();
            ClientsCount = ClientsList.Count;
        }
        public int ClientsCount { get; private set; }
        public List<Client> ClientsList { get; set; }

        public void AddClient(string name, string surname)
        {
            if (String.IsNullOrEmpty(name) || String.IsNullOrEmpty(surname)) return;

            ClientsList.Add(new Client(name, surname) as TClient);
            ClientsCount = ClientsList.Count;
        }
        public void RemoveClient(string name, string surname)
        {
            if (String.IsNullOrEmpty(name) || String.IsNullOrEmpty(surname)) return;

            foreach (var client in ClientsList)
            {
                if (client.Name == name && client.Surname == surname)
                {
                    ClientsList.Remove(client);
                    ClientsCount = ClientsList.Count;
                    break;
                }
            }
        }
    }
}