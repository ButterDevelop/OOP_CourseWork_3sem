using DB_CourseWork.DbRepositories.Csv;
using DB_CourseWork.DbRepositories.Sql;
using DB_CourseWork.Interfaces;
using DB_CourseWork.Models;
using System.Collections.Generic;

namespace DB_CourseWork.Controls
{
    class DatabaseContext
    {
        public static DatabaseContext DbContext;

        public IClientStrategy Clients { get; set; }
        public IEmployeeStrategy Employees { get; set; }
        public IAdminStrategy Admins { get; set; }
        public ICarStrategy Cars { get; set; }
        public IOrderStrategy Orders { get; set; }
        public IPaymentStrategy Payments { get; set; }
        public IBankTransactionStrategy BankTransactions { get; set; }
        public IServiceReportStrategy ServiceReports { get; set; }

        public User CurrentUser { get; set; }

        public DatabaseContext(IClientStrategy clients, IEmployeeStrategy employees, IAdminStrategy admins, ICarStrategy cars, IOrderStrategy orders, IPaymentStrategy payments, 
                               IBankTransactionStrategy bankTransactions, IServiceReportStrategy serviceReports)
        {
            Clients = clients;
            Employees = employees;
            Admins = admins;
            Cars = cars;
            Orders = orders;
            Payments = payments;
            BankTransactions = bankTransactions;
            ServiceReports = serviceReports;
        }

        public List<User> GetAllUsers()
        {
            List<User> users = new List<User>();
            foreach (var client in Clients.GetAll()) users.Add(client);
            foreach (var employee in Employees.GetAll()) users.Add(employee);
            foreach (var admin in Admins.GetAll()) users.Add(admin);
            return users;
        }


        public static DatabaseContext GenerateDBContext(DbType dbType)
        {
            switch (dbType)
            {
                case DbType.CSV:   return new DatabaseContext(new CsvClientRepository(), new CsvEmployeeRepository(), new CsvAdminRepository(), 
                                                              new CsvCarRepository(),    new CsvOrderRepository(),    new CsvPaymentRepository(), 
                                                              new CsvBankTransactionRepository(), new CsvServiceReportRepository()); 
                /*
                case DbType.Mongo: return new DatabaseContext(new MongoClientRepository(), new MongoEmployeeRepository(), new MongoAdminRepository(),
                                                              new MongoCarRepository(),    new MongoOrderRepository(),    new MongoPaymentRepository(), 
                                                              new MongoBankTransactionRepository(), new MongoServiceReportRepository());
                */
                case DbType.SQL:   string connectionString = Config.SQL_CONNECTION_STRING;
                                   return new DatabaseContext(new SqlClientRepository(connectionString), new SqlEmployeeRepository(connectionString), 
                                                              new SqlAdminRepository(connectionString), new SqlCarRepository(connectionString), 
                                                              new SqlOrderRepository(connectionString), new SqlPaymentRepository(connectionString),
                                                              new SqlBankTransactionRepository(connectionString), 
                                                              new SqlServiceReportRepository(connectionString));
            }
            return null;
        }

    }
}
