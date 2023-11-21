using DB_CourseWork.Interfaces;
using DB_CourseWork.Models;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DB_CourseWork.DbRepositories.Sql
{
    public class SqlEmployeeRepository : IEmployeeStrategy
    {
        private readonly string _connectionString;

        public SqlEmployeeRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Employee> GetAll()
        {
            var employees = new List<Employee>();

            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("SELECT Users.*, Employees.UserId, Employees.OrdersProcessed, Employees.DaysWorked, Employees.DateHired, " +
                                             "Employees.DateFired, Employees.DateLastSalaryPayed, Employees.BankAccountNumber, " +
                                             "Employees.TotalSalaryPaid, Employees.IsWorkingNow FROM Employees " +
                                             "JOIN Users ON Employees.UserId = Users.Id", connection);
                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var employee = MapSqlReaderToObject(reader);
                        employees.Add(employee);
                    }
                }
            }

            return employees;
        }

        public Employee Get(int id)
        {
            Employee employee = null;

            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("SELECT Users.*, Employees.UserId, Employees.OrdersProcessed, Employees.DaysWorked, Employees.DateHired, " +
                                             "Employees.DateFired, Employees.DateLastSalaryPayed, Employees.BankAccountNumber, " +
                                             "Employees.TotalSalaryPaid, Employees.IsWorkingNow FROM Employees " +
                                             "JOIN Users ON Employees.UserId = Users.Id " +
                                             "WHERE Users.Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);

                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        employee = MapSqlReaderToObject(reader);
                    }
                }
            }

            return employee;
        }

        public void Add(Employee employee)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("INSERT INTO Users (Username, Salt, HashedPassword, FullName, Email, Phone, Role, IsAccountSetupCompleted, AccountDeactivated) " +
                                             "VALUES (@Username, @Salt, @HashedPassword, @FullName, @Email, @Phone, @Role, @IsAccountSetupCompleted, @AccountDeactivated); " +
                                             "SELECT CAST(scope_identity() AS int);", connection);

                command.Parameters.AddWithValue("@Username",                employee.UserName);
                command.Parameters.AddWithValue("@Salt",                    employee.Salt);
                command.Parameters.AddWithValue("@HashedPassword",          employee.HashedPassword);
                command.Parameters.AddWithValue("@FullName",                employee.FullName);
                command.Parameters.AddWithValue("@Email",                   employee.Email);
                command.Parameters.AddWithValue("@Phone",                   employee.Phone);
                command.Parameters.AddWithValue("@Role",                    (int)employee.Role);
                command.Parameters.AddWithValue("@IsAccountSetupCompleted", employee.IsAccountSetupCompleted);
                command.Parameters.AddWithValue("@AccountDeactivated",      employee.AccountDeactivated);

                connection.Open();
                int userId = (int)command.ExecuteScalar(); // Исполняем и получаем ID пользователя

                command.CommandText = "INSERT INTO Employees (UserId, OrdersProcessed, DaysWorked, DateHired, DateFired, DateLastSalaryPayed, BankAccountNumber, TotalSalaryPaid, IsWorkingNow) " +
                                      "VALUES (@UserId, @OrdersProcessed, @DaysWorked, @DateHired, @DateFired, @DateLastSalaryPayed, @BankAccountNumber, @TotalSalaryPaid, @IsWorkingNow);";

                command.Parameters.AddWithValue("@UserId",                  userId);
                command.Parameters.AddWithValue("@OrdersProcessed",         employee.OrderProccessed);
                command.Parameters.AddWithValue("@DaysWorked",              employee.DaysWorked);
                command.Parameters.AddWithValue("@DateHired",               employee.DateHired);
                command.Parameters.AddWithValue("@DateFired",               employee.DateFired);
                command.Parameters.AddWithValue("@DateLastSalaryPayed",     employee.DateLastSalaryPayed);
                command.Parameters.AddWithValue("@BankAccountNumber",       employee.BankAccountNumber);
                command.Parameters.AddWithValue("@TotalSalaryPaid",         employee.TotalSalaryPayed);
                command.Parameters.AddWithValue("@IsWorkingNow",            employee.IsWorkingNow);

                command.ExecuteNonQuery(); // Исполняем вставку в таблицу сотрудников
            }
        }

        public void Update(Employee employee)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("UPDATE Users SET Username = @Username, Salt = @Salt, HashedPassword = @HashedPassword, " +
                                             "FullName = @FullName, Email = @Email, Phone = @Phone, Role = @Role, " +
                                             "IsAccountSetupCompleted = @IsAccountSetupCompleted, AccountDeactivated = @AccountDeactivated " +
                                             "WHERE Id = @UserId; " +
                                             "UPDATE Employees SET OrdersProcessed = @OrdersProcessed, DaysWorked = @DaysWorked, " +
                                             "DateHired = @DateHired, DateFired = @DateFired, DateLastSalaryPayed = @DateLastSalaryPayed, " +
                                             "BankAccountNumber = @BankAccountNumber, TotalSalaryPaid = @TotalSalaryPaid, " +
                                             "IsWorkingNow = @IsWorkingNow WHERE UserId = @UserId;", connection);

                command.Parameters.AddWithValue("@UserId",                  employee.Id);
                command.Parameters.AddWithValue("@Username",                employee.UserName);
                command.Parameters.AddWithValue("@Salt",                    employee.Salt);
                command.Parameters.AddWithValue("@HashedPassword",          employee.HashedPassword);
                command.Parameters.AddWithValue("@FullName",                employee.FullName);
                command.Parameters.AddWithValue("@Email",                   employee.Email);
                command.Parameters.AddWithValue("@Phone",                   employee.Phone);
                command.Parameters.AddWithValue("@Role",                    (int)employee.Role);
                command.Parameters.AddWithValue("@IsAccountSetupCompleted", employee.IsAccountSetupCompleted);
                command.Parameters.AddWithValue("@AccountDeactivated",      employee.AccountDeactivated);

                command.Parameters.AddWithValue("@OrdersProcessed",         employee.OrderProccessed);
                command.Parameters.AddWithValue("@DaysWorked",              employee.DaysWorked);
                command.Parameters.AddWithValue("@DateHired",               employee.DateHired);
                command.Parameters.AddWithValue("@DateFired",               employee.DateFired);
                command.Parameters.AddWithValue("@DateLastSalaryPayed",     employee.DateLastSalaryPayed);
                command.Parameters.AddWithValue("@BankAccountNumber",       employee.BankAccountNumber);
                command.Parameters.AddWithValue("@TotalSalaryPaid",         employee.TotalSalaryPayed);
                command.Parameters.AddWithValue("@IsWorkingNow",            employee.IsWorkingNow);

                connection.Open();
                command.ExecuteNonQuery(); // Исполняем обновление
            }
        }

        public void Delete(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("DELETE FROM Employees WHERE UserId = @UserId; DELETE FROM Users WHERE Id = @UserId;", connection);
                command.Parameters.AddWithValue("@UserId", id);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public Employee MapSqlReaderToObject(SqlDataReader reader)
        {
            return new Employee
            {
                Id                      = reader.GetInt32(reader.GetOrdinal("UserId")),
                UserName                = reader.GetString(reader.GetOrdinal("Username")),
                Salt                    = reader.GetString(reader.GetOrdinal("Salt")),
                HashedPassword          = reader.GetString(reader.GetOrdinal("HashedPassword")),
                FullName                = reader.GetString(reader.GetOrdinal("Fullname")),
                Email                   = reader.GetString(reader.GetOrdinal("Email")),
                Phone                   = reader.GetString(reader.GetOrdinal("Phone")),
                Role                    = (RolesContainer)reader.GetInt32(reader.GetOrdinal("Role")),
                IsAccountSetupCompleted = reader.GetBoolean(reader.GetOrdinal("IsAccountSetupCompleted")),
                AccountDeactivated      = reader.GetBoolean(reader.GetOrdinal("AccountDeactivated")),
                OrderProccessed         = reader.GetInt32(reader.GetOrdinal("OrdersProcessed")),
                DaysWorked              = reader.GetInt32(reader.GetOrdinal("DaysWorked")),
                DateHired               = reader.GetDateTime(reader.GetOrdinal("DateHired")),
                DateFired               = reader.GetDateTime(reader.GetOrdinal("DateFired")),
                DateLastSalaryPayed     = reader.GetDateTime(reader.GetOrdinal("DateLastSalaryPayed")),
                BankAccountNumber       = reader.GetString(reader.GetOrdinal("BankAccountNumber")),
                TotalSalaryPayed        = reader.GetDouble(reader.GetOrdinal("TotalSalaryPaid")),
                IsWorkingNow            = reader.GetBoolean(reader.GetOrdinal("IsWorkingNow")),
            };
        }
    }
}
