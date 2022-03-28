using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using DataAccess.Interfaces;
using HomeWork.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Implementation
{
    public partial class BankSystemContext : DbContext, IDbContext
    {
        public BankSystemContext()
        {
        }

        public BankSystemContext(DbContextOptions<BankSystemContext> options)
            : base(options)
        { }

        public virtual DbSet<Account> Accounts { get; set; }

        public virtual DbSet<Client> Clients { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    "Server=(localdb)\\MSSQLLocalDB; " +
                    "Database=BankSystem; " +
                    "Trusted_Connection=true;");
            }

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Client>()
                .HasMany(c => c.Accounts)
                .WithOne(a => a.Client)
                .HasForeignKey(c => c.ClientId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Client>()
                .HasAlternateKey(x => new {x.Name, x.Surname}).HasName("UQ_Client");

            modelBuilder.Entity<Client>()
                .HasKey(x => x.Id);

           modelBuilder.Entity<Account>()
                .HasAlternateKey(x => x.AccountNumber)
                .HasName("UQ_Account");

            modelBuilder.Entity<Account>()
                .HasKey(x => x.Id).HasName("PK_Account");


        }

        public void SaveChange(List<Client> clients)
        {
            foreach (var client in clients)
            {
                var dbClient = Clients.Find(client.Id);
                if (dbClient != null) 
                    dbClient.Accounts = client.Accounts;

            }

            SaveChanges();
        }

    }
}
