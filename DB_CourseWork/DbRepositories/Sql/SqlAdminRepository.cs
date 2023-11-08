using DB_CourseWork.Interfaces;
using DB_CourseWork.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DB_CourseWork.DbRepositories.Sql
{
    class SqlAdminRepository : IAdminStrategy
    {
        private readonly string _connectionString;

        public SqlAdminRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Connect()
        {
            
        }

        public List<Admin> GetAll()
        {
            var admins = new List<Admin>();

            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("SELECT Users.*, Admins.TotalCarsServiced FROM Admins JOIN Users ON Admins.UserId = Users.Id", connection);
                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var admin = MapSqlReaderToObject(reader);
                        admins.Add(admin);
                    }
                }
            }

            return admins;
        }

        public Admin Get(int id)
        {
            Admin admin = null;

            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("SELECT * FROM Admins JOIN Users ON Admins.UserId = Users.Id WHERE Users.Id = @Id", connection);
                command.Parameters.Add(new SqlParameter("@Id", id));
                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        admin = MapSqlReaderToObject(reader);
                    }
                }
            }

            return admin;
        }

        public void Add(Admin admin)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("INSERT INTO Users (Username, Salt, HashedPassword, Fullname, Email, Phone, Role, IsAccountSetupCompleted, AccountDeactivated) " +
                                             "VALUES (@Username, @Salt, @HashedPassword, @Fullname, @Email, @Phone, @Role, @IsAccountSetupCompleted, @AccountDeactivated); " +
                                             "SELECT SCOPE_IDENTITY();", connection);

                command.Parameters.AddWithValue("@Username",                admin.UserName);
                command.Parameters.AddWithValue("@Salt",                    admin.Salt);
                command.Parameters.AddWithValue("@HashedPassword",          admin.HashedPassword);
                command.Parameters.AddWithValue("@FullName",                admin.FullName);
                command.Parameters.AddWithValue("@Email",                   admin.Email);
                command.Parameters.AddWithValue("@Phone",                   admin.Phone);
                command.Parameters.AddWithValue("@Role",                    (int)admin.Role);
                command.Parameters.AddWithValue("@IsAccountSetupCompleted", admin.IsAccountSetupCompleted);
                command.Parameters.AddWithValue("@AccountDeactivated",      admin.AccountDeactivated);

                connection.Open();

                // Выполняем запрос и получаем ID пользователя
                int userId = Convert.ToInt32(command.ExecuteScalar());

                command.CommandText = "INSERT INTO Admins (UserId, TotalCarsServiced) VALUES (@UserId, @TotalCarsServiced)";

                // Параметры для Admins
                command.Parameters.AddWithValue("@UserId",                   userId);
                command.Parameters.AddWithValue("@TotalCarsServiced",        admin.TotalCarsServiced);

                // Выполняем вставку администратора
                command.ExecuteNonQuery();
            }
        }

        public void Update(Admin admin)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("UPDATE Users SET Username = @Username, Salt = @Salt, HashedPassword = @HashedPassword, " +
                                             "Fullname = @Fullname, Email = @Email, Phone = @Phone, Role = @Role, " +
                                             "IsAccountSetupCompleted = @IsAccountSetupCompleted, AccountDeactivated = @AccountDeactivated " +
                                             "WHERE Id = @UserId; " +
                                             "UPDATE Admins SET TotalCarsServiced = @TotalCarsServiced WHERE UserId = @UserId", connection);

                // Параметры для Users
                command.Parameters.AddWithValue("@UserId",                   admin.Id);
                command.Parameters.AddWithValue("@Username",                 admin.UserName);
                command.Parameters.AddWithValue("@Salt",                     admin.Salt);
                command.Parameters.AddWithValue("@HashedPassword",           admin.HashedPassword);
                command.Parameters.AddWithValue("@FullName",                 admin.FullName);
                command.Parameters.AddWithValue("@Email",                    admin.Email);
                command.Parameters.AddWithValue("@Phone",                    admin.Phone);
                command.Parameters.AddWithValue("@Role",                     (int)admin.Role);
                command.Parameters.AddWithValue("@IsAccountSetupCompleted",  admin.IsAccountSetupCompleted);
                command.Parameters.AddWithValue("@AccountDeactivated",       admin.AccountDeactivated);

                // Параметры для Admins
                command.Parameters.AddWithValue("@TotalCarsServiced",        admin.TotalCarsServiced);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("DELETE FROM Admins WHERE UserId = @Id; " +
                                             "DELETE FROM Users WHERE Id = @Id", connection);
                command.Parameters.Add(new SqlParameter("@Id", id));
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public Admin MapSqlReaderToObject(SqlDataReader reader)
        {
            return new Admin
            {
                Id                      = reader.GetInt32(reader.GetOrdinal("Id")),
                UserName                = reader.GetString(reader.GetOrdinal("Username")),
                Salt                    = reader.GetString(reader.GetOrdinal("Salt")),
                HashedPassword          = reader.GetString(reader.GetOrdinal("HashedPassword")),
                FullName                = reader.GetString(reader.GetOrdinal("Fullname")),
                Email                   = reader.GetString(reader.GetOrdinal("Email")),
                Phone                   = reader.GetString(reader.GetOrdinal("Phone")),
                Role                    = (RolesContainer)reader.GetInt32(reader.GetOrdinal("Role")),
                IsAccountSetupCompleted = reader.GetBoolean(reader.GetOrdinal("IsAccountSetupCompleted")),
                AccountDeactivated      = reader.GetBoolean(reader.GetOrdinal("AccountDeactivated")),
                TotalCarsServiced       = reader.GetInt32(reader.GetOrdinal("TotalCarsServiced"))
            };
        }

    }
}
