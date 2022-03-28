using System;
using HomeWork.Entities;
using System.Collections.Generic;

namespace Database
{
    public class Database
    {
        private List<Client> _clientsList;
        public Database()
        {
            _clientsList = new List<Client>();
            var rnd = new Random();

            // Создание базы клиентов
            _clientsList.Add(new Client("Фёдор", "Зиновьев"));
            _clientsList.Add(new Client("Михаил", "Зыков"));
            _clientsList.Add(new Client("Селезнева", "Амелия"));
            _clientsList.Add(new Client("Виктория", "Алексеева"));
            _clientsList.Add(new Client("Илья", "Иванов"));
            _clientsList.Add(new Client("Аделина", "Аделина"));
            _clientsList.Add(new Client("Николай", "Кузнецов"));

            // Создание баны банковских счетов клиентов
            foreach (var client in _clientsList)
            {
                client.AddSimpleAccount();
                client.AddDepositAccount();
                client.AddSimpleAccount();
                client.AddDepositAccount();
                foreach (IAccount item in client.GetAccounts())
                {
                    item.AddBalance(rnd.Next(30, 70) * 1000);
                }
            }
        }

        public List<Client> ClientsList
        {
            get => _clientsList;
            set => _clientsList = value;
        }

    }
}
