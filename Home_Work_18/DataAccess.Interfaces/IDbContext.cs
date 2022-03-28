using System.Collections.Generic;
using HomeWork.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Interfaces
{
    public interface IDbContext
    {
        DbSet<Client> Clients { get; }

        DbSet<Account> Accounts { get; }

        void SaveChange(List<Client> clients);

    }
}