using System;
using System.Collections.Generic;
using HomeWork.Entities;

namespace UseCases.Interfeces
{
    public interface IReposytory<TClient>
    {
        void CreateClient(string firstName, string lastName);
        void UpdateClient(string firstName, string lastName);
        void DeleteClient(string firstName, string lastName);
        TClient ReadClient(string firstName, string lastName);
        List<TClient> GetClients();

    }
}
