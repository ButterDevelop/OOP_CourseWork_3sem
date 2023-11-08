using DB_CourseWork.Interfaces;
using DB_CourseWork.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DB_CourseWork.DbRepositories.Sql
{
    class SqlClientRepository : IClientStrategy
    {
        private readonly string _connectionString;

        public SqlClientRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Connect()
        {
            
        }

        public List<Client> GetAll()
        {
            var clients = new List<Client>();

            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("SELECT * FROM Users INNER JOIN Clients ON Users.Id = Clients.UserId", connection);
                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var client = MapSqlReaderToObject(reader);

                        clients.Add(client);
                    }
                }
            }

            return clients;
        }

        public Client Get(int id)
        {
            Client client = null;

            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("SELECT * FROM Users INNER JOIN Clients ON Users.Id = Clients.UserId WHERE Users.Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);

                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        client = MapSqlReaderToObject(reader);
                    }
                }
            }

            return client;
        }

        public void Add(Client client)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("INSERT INTO Users (Username, Salt, HashedPassword, Fullname, Email, Phone, Role, IsAccountSetupCompleted, AccountDeactivated) " +
                "VALUES (@Username, @Salt, @HashedPassword, @Fullname, @Email, @Phone, @Role, @IsAccountSetupCompleted, @AccountDeactivated); " +
                "SELECT SCOPE_IDENTITY();", connection);

                command.Parameters.AddWithValue("@Username",                client.UserName);
                command.Parameters.AddWithValue("@Salt",                    client.Salt);
                command.Parameters.AddWithValue("@HashedPassword",          client.HashedPassword);
                command.Parameters.AddWithValue("@Fullname",                client.FullName);
                command.Parameters.AddWithValue("@Email",                   client.Email);
                command.Parameters.AddWithValue("@Phone",                   client.Phone);
                command.Parameters.AddWithValue("@Role",                    client.Role);
                command.Parameters.AddWithValue("@IsAccountSetupCompleted", client.IsAccountSetupCompleted);
                command.Parameters.AddWithValue("@AccountDeactivated",      client.AccountDeactivated);

                connection.Open();
                var userId = Convert.ToInt32(command.ExecuteScalar());

                command = new SqlCommand("INSERT INTO Clients (UserId, DriverLicense, Passport, CardNumber, Balance, SumRating, OrdersCount) " +
                "VALUES (@UserId, @DriverLicense, @Passport, @CardNumber, @Balance, @SumRating, @OrdersCount)", connection);

                command.Parameters.AddWithValue("@UserId",                  userId);
                command.Parameters.AddWithValue("@DriverLicense",           client.DriverLicense);
                command.Parameters.AddWithValue("@Passport",                client.Passport);
                command.Parameters.AddWithValue("@CardNumber",              client.CardNumber);
                command.Parameters.AddWithValue("@Balance",                 client.Balance);
                command.Parameters.AddWithValue("@SumRating",               client.SumRating);
                command.Parameters.AddWithValue("@OrdersCount",             client.OrderCount);

                command.ExecuteNonQuery();
            }
        }

        public void Update(Client client)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("UPDATE Users SET Username = @Username, Salt = @Salt, HashedPassword = @HashedPassword, " +
                "Fullname = @Fullname, Email = @Email, Phone = @Phone, Role = @Role, " +
                "IsAccountSetupCompleted = @IsAccountSetupCompleted, AccountDeactivated = @AccountDeactivated " +
                "WHERE Id = @Id; " +
                "UPDATE Clients SET DriverLicense = @DriverLicense, Passport = @Passport, CardNumber = @CardNumber, " +
                "Balance = @Balance, SumRating = @SumRating, OrdersCount = @OrdersCount WHERE UserId = @Id", connection);

                command.Parameters.AddWithValue("@Id",                      client.Id);
                command.Parameters.AddWithValue("@Username",                client.UserName);
                command.Parameters.AddWithValue("@Salt",                    client.Salt);
                command.Parameters.AddWithValue("@HashedPassword",          client.HashedPassword);
                command.Parameters.AddWithValue("@Fullname",                client.FullName);
                command.Parameters.AddWithValue("@Email",                   client.Email);
                command.Parameters.AddWithValue("@Phone",                   client.Phone);
                command.Parameters.AddWithValue("@Role",                    client.Role);
                command.Parameters.AddWithValue("@IsAccountSetupCompleted", client.IsAccountSetupCompleted);
                command.Parameters.AddWithValue("@AccountDeactivated",      client.AccountDeactivated);
                command.Parameters.AddWithValue("@DriverLicense",           client.DriverLicense);
                command.Parameters.AddWithValue("@Passport",                client.Passport);
                command.Parameters.AddWithValue("@CardNumber",              client.CardNumber);
                command.Parameters.AddWithValue("@Balance",                 client.Balance);
                command.Parameters.AddWithValue("@SumRating",               client.SumRating);
                command.Parameters.AddWithValue("@OrdersCount",             client.OrderCount);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("DELETE FROM Clients WHERE UserId = @Id; DELETE FROM Users WHERE Id = @Id;", connection);
                command.Parameters.AddWithValue("@Id", id);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public Client MapSqlReaderToObject(SqlDataReader reader)
        {
            return new Client
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
                DriverLicense           = reader.GetString(reader.GetOrdinal("DriverLicense")),
                Passport                = reader.GetString(reader.GetOrdinal("Passport")),
                CardNumber              = reader.GetString(reader.GetOrdinal("CardNumber")),
                Balance                 = reader.GetDouble(reader.GetOrdinal("Balance")),
                SumRating               = reader.GetDouble(reader.GetOrdinal("SumRating")),
                OrderCount              = reader.GetInt32(reader.GetOrdinal("OrdersCount")),
            };
        }

    }
}
