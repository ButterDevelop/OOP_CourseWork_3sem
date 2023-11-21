using DB_CourseWork.DbRepositories.Csv;
using DB_CourseWork.DbRepositories.Mongo;
using DB_CourseWork.DbRepositories.Sql;
using DB_CourseWork.Interfaces;
using DB_CourseWork.Models;
using System.Collections.Generic;

namespace DB_CourseWork.Controls
{
    class DatabaseContext
    {
        public static DatabaseContext DbContext;
        public static string DatabaseTypeName = "";
        public static DbType ChosenDbType = DbType.None;

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
                case DbType.Mongo: string mongoConnectionString = Config.MONGO_CONNECTION_STRING, mongoDatabaseName = Config.MONGO_DATABASE_NAME;
                                   return new DatabaseContext(new MongoClientRepository(mongoConnectionString, mongoDatabaseName),
                                                              new MongoEmployeeRepository(mongoConnectionString, mongoDatabaseName),
                                                              new MongoAdminRepository(mongoConnectionString, mongoDatabaseName),
                                                              new MongoCarRepository(mongoConnectionString, mongoDatabaseName),
                                                              new MongoOrderRepository(mongoConnectionString, mongoDatabaseName),
                                                              new MongoPaymentRepository(mongoConnectionString, mongoDatabaseName),
                                                              new MongoBankTransactionRepository(mongoConnectionString, mongoDatabaseName), 
                                                              new MongoServiceReportRepository(mongoConnectionString, mongoDatabaseName));
                case DbType.SQL:   string sqlConnectionString = Config.SQL_CONNECTION_STRING;
                                   return new DatabaseContext(new SqlClientRepository(sqlConnectionString), new SqlEmployeeRepository(sqlConnectionString), 
                                                              new SqlAdminRepository(sqlConnectionString), new SqlCarRepository(sqlConnectionString), 
                                                              new SqlOrderRepository(sqlConnectionString), new SqlPaymentRepository(sqlConnectionString),
                                                              new SqlBankTransactionRepository(sqlConnectionString), 
                                                              new SqlServiceReportRepository(sqlConnectionString));
            }
            return null;
        }

    }
}
