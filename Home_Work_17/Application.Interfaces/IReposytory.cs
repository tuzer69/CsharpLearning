using System.Collections.Generic;
using System.Threading.Tasks;
using HomeWork.Entities;

namespace UseCases.Interfeces
{
    public interface IReposytory<TClient>
    {
        void CreateClient(string firstName, string lastName);
        void UpdateClient(string firstName, string lastName);
        void DeleteClient(string firstName, string lastName);
        TClient ReadClient(string firstName, string lastName);
        void Updatadatabase(List<TClient> database);
        List<Client> GetClients();

    }
}
