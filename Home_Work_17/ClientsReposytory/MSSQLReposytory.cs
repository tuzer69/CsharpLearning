using System;
using System.Collections;
using HomeWork.Entities;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Windows.Navigation;
using System.Xml.Linq;
using UseCases.Interfeces;

namespace ClientsReposytory
{
    public class MSSQLReposytory : IReposytory<Client>
    {
        private DataSet _bankDataSet;

        private SqlDataAdapter _adapter;

        private static SqlConnectionStringBuilder _connectionString;

        private readonly string readCommandText =
            "SELECT Id, FName, LName FROM Clients; " +
            "SELECT ClientId, AccNumber, IsDeposit, Balance FROM Accounts";

        private readonly string getAccountsCommandText =
            "SELECT * FROM Accounts";

        public MSSQLReposytory()
        {
            _connectionString = new SqlConnectionStringBuilder
            {
                DataSource = "(localdb)\\MSSQLLocalDB",
                InitialCatalog = "BankSystem",
                IntegratedSecurity = true,
                Pooling = true

            };

            _bankDataSet = new DataSet();
        }

        public void CreateClient(string firstName, string lastName)
        {
            
        }

        public void DeleteClient(string firstName, string lastName)
        {
           
        }
        
        public Client ReadClient(string firstName, string lastName)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateClient(string firstName, string lastName)
        {
        }

        public void Updatadatabase(List<Client> database)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString.ConnectionString))
            {
                _adapter = new SqlDataAdapter(getAccountsCommandText, connection);

                _adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;

                var controller = new DataBaseController(connection);

                var accounts = new DataTable("Accounts");

                _adapter.Fill(accounts);

                controller.Fill(_adapter);

                controller.Update(accounts, database);

                _adapter.Update(accounts);
            }
        }

        public  List<Client> GetClients()
        {
            var result = new List<Client>();

            using (SqlConnection connection = new SqlConnection(_connectionString.ConnectionString))
            {
                _adapter = new SqlDataAdapter(readCommandText, connection);

                _adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                _adapter.TableMappings.Add("Table", "Clients"); 
                _adapter.TableMappings.Add("Table1", "Accounts");
                _adapter.Fill(_bankDataSet);

                var clients =
                    from client in _bankDataSet.Tables["Clients"]?.AsEnumerable()
                    join accounts in _bankDataSet.Tables["Accounts"]?.AsEnumerable()
                        on client.Field<int>("Id") equals accounts.Field<int>("ClientId") 
                        into accs
                    select new Client(
                        client.Field<string>("FName"),
                        client.Field<string>("LName"),
                        accs.ToAccounts()
                        );

                result = clients.ToList();

            }
            
            return result;
        }

        class DataBaseController
        {
            private readonly SqlConnection _connection;

            public DataBaseController(SqlConnection connection)
            {
                _connection = connection;
            }

            public void Fill(SqlDataAdapter adapter)
            {
                adapter.UpdateCommand = new SqlCommand(
                    "UPDATE Accounts SET AccNumber = @AccNumber, Balance = @Balance " +
                    "WHERE AccNumber = @AccNumber", _connection);
                adapter.UpdateCommand.Parameters.Add(
                    new SqlParameter("@AccNumber", SqlDbType.Int, 0, "AccNumber"));
                adapter.UpdateCommand.Parameters.Add(
                    new SqlParameter("@Balance", SqlDbType.Int, 0, "Balance"));

                adapter.InsertCommand = new SqlCommand(
                    "INSERT Accounts VALUES (@ClientId, @AccNumber, @IsDeposit, @Balance)", _connection);
                adapter.InsertCommand.Parameters.Add("@ClientId", SqlDbType.Int, 0, "ClientId");
                adapter.InsertCommand.Parameters.Add("@AccNumber", SqlDbType.Int, 0, "AccNumber");
                adapter.InsertCommand.Parameters.Add("@IsDeposit", SqlDbType.Bit, 0, "IsDeposit");
                adapter.InsertCommand.Parameters.Add("@Balance", SqlDbType.Int, 0, "Balance");

                adapter.DeleteCommand = new SqlCommand(
                    "DELETE FROM Accounts WHERE AccNumber = @AccNumber", _connection);
                adapter.DeleteCommand.Parameters.Add("@AccNumber", SqlDbType.Int, 0, "AccNumber");

            }

            public void Update(DataTable table, List<Client> dataClients)
            {
                var infoDb = getInfo(table, dataClients);

                using (SqlConnection connection = new SqlConnection(_connectionString.ConnectionString))
                {
                    SqlDataAdapter _adapter =
                        new SqlDataAdapter("SELECT * FROM Clients", connection);
                    var clients = new DataTable("Clients");
                    _adapter.Fill(clients);

                    foreach (var acc in infoDb.addedAcc)
                    {
                        int ClinentId = clients
                            .AsEnumerable()
                            .Where(n => n.Field<string>("FName") == acc.Name)
                            .Where(n => n.Field<string>("LName") == acc.Surname)
                            .Select(n => n.Field<int>("Id")).First();



                        var newrow = table.NewRow();
                        newrow["AccNumber"] = acc.AccNumber;
                        newrow["ClientId"] = ClinentId;
                        newrow["IsDeposit"] = acc.IsDeposit;
                        newrow["Balance"] = acc.Balance;


                        table.Rows.Add(newrow);
                    }
                }

                foreach (DataRow row in table.Rows)
                {

                    var dbnumber = row.Field<int>("AccNumber");

                    if(infoDb.newAccs.Contains(dbnumber))
                    {

                        int balance =
                            dataClients
                                .SelectMany(n => n.Accounts)
                                .Where(n => n.AccountNumber == dbnumber)
                                .Select(n => (int) n.Balance).First();

                        row.SetField("Balance", balance);
                    }
                    else row.Delete();
                }

            }
            /// <summary>
            /// Метод с помощью LINQ достают информацию из базы данных
            /// </summary>
            /// <param name="table">Ссылка на DataTable</param>
            /// <param name="dataClients">Ссылка на Новую коллекци с клиентами</param>
            /// <returns>Возвращает структуру с описанием базы даных</returns>
            private dbInfo getInfo(DataTable table, List<Client> dataClients)
            {
                var infoBag = new dbInfo();

                var oldAccs = table
                    .AsEnumerable()
                    .Select(x => x.Field<int>("AccNumber"));

                var newAccs =
                    from client in dataClients.Select(a => a.Accounts)
                    from accs in client.Select(n => (int)n.AccountNumber)
                    select accs;
                var addedAcc =
                    from client in dataClients.Select(a => a.Accounts)
                    from accs in client
                        .Select(n => new
                        {
                            Name = dataClients
                                .Where(x => x.Accounts.Contains(n))
                                .Select(i => i.Name).First(),
                            Surname = dataClients
                                .Where(x => x.Accounts.Contains(n))
                                .Select(i => i.Surname).First(),
                            AccNumber = (int) n.AccountNumber,
                            Balance = n.Balance,
                            IsDeposit = n.IsDeposit,

                        })
                        .Where(n => !oldAccs.Contains(n.AccNumber))
                    select accs;

                infoBag.oldAccs = oldAccs;
                infoBag.newAccs = newAccs;
                infoBag.addedAcc = addedAcc;

                return infoBag;
            }

            private struct dbInfo
            {
                public dbInfo(DataTable table, List<Client> dataClients) : this()
                {
                    Table = table;
                    DataClients = dataClients;
                }

                public EnumerableRowCollection<int> oldAccs { get; set; }
                public IEnumerable<int> newAccs { get; set; }
                public dynamic addedAcc { get; set; }
                public DataTable Table { get; }
                public List<Client> DataClients { get; }
            }
        }

    }


    static class ListExtension
    {
        public static List<Account> ToAccounts(this IEnumerable<DataRow> rows)
        {
            var accs = new List<Account>();

            foreach (DataRow row in rows)
            {
                if (row.Field<bool>("IsDeposit"))
                {
                    accs.Add(
                    new DepositAccount
                    {
                        AccountNumber = (uint)row.Field<int>("AccNumber"),
                        Balance = row.Field<int>("Balance")
                    });
                }
                else
                {
                    accs.Add(
                        new SimpleAccount
                        {
                            AccountNumber = (uint)row.Field<int>("AccNumber"),
                            Balance = row.Field<int>("Balance")
                        });
                }
                
            }

            return accs;
        }
    }

}