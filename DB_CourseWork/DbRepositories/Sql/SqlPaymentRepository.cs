using DB_CourseWork.Interfaces;
using DB_CourseWork.Models;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DB_CourseWork.DbRepositories.Sql
{
    class SqlPaymentRepository : IPaymentStrategy
    {
        private string _connectionString;

        public SqlPaymentRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Connect()
        {
            
        }

        public List<Payment> GetAll()
        {
            var payments = new List<Payment>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand("SELECT * FROM Payments", connection);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var payment = MapSqlReaderToObject(reader);
                        payments.Add(payment);
                    }
                }
            }
            return payments;
        }

        public Payment Get(int id)
        {
            Payment payment = null;
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand("SELECT * FROM Payments WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        payment = MapSqlReaderToObject(reader);
                    }
                }
            }
            return payment;
        }

        public void Add(Payment entity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand(@"INSERT INTO Payments (CreatedTime, PayedTime, UserId, Cost, IsPayed, IsRefunded) 
                                           VALUES (@CreatedTime, @PayedTime, @UserId, @Cost, @IsPayed, @IsRefunded)", connection);
                command.Parameters.AddWithValue("@CreatedTime", entity.CreatedTime);
                command.Parameters.AddWithValue("@PayedTime",   entity.PayedTime);
                command.Parameters.AddWithValue("@UserId",      entity.UserId);
                command.Parameters.AddWithValue("@Cost",        entity.Cost);
                command.Parameters.AddWithValue("@IsPayed",     entity.IsPayed);
                command.Parameters.AddWithValue("@IsRefunded",  entity.IsRefunded);

                command.ExecuteNonQuery();
            }
        }

        public void Update(Payment entity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand(@"UPDATE Payments SET 
                                            CreatedTime = @CreatedTime, 
                                            PayedTime = @PayedTime, 
                                            UserId = @UserId, 
                                            Cost = @Cost, 
                                            IsPayed = @IsPayed, 
                                            IsRefunded = @IsRefunded 
                                           WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id",          entity.Id);
                command.Parameters.AddWithValue("@CreatedTime", entity.CreatedTime);
                command.Parameters.AddWithValue("@PayedTime",   entity.PayedTime);
                command.Parameters.AddWithValue("@UserId",      entity.UserId);
                command.Parameters.AddWithValue("@Cost",        entity.Cost);
                command.Parameters.AddWithValue("@IsPayed",     entity.IsPayed);
                command.Parameters.AddWithValue("@IsRefunded",  entity.IsRefunded);

                command.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand("DELETE FROM Payments WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);
                command.ExecuteNonQuery();
            }
        }

        public Payment MapSqlReaderToObject(SqlDataReader reader)
        {
            return new Payment
            {
                Id          = reader.GetInt32(reader.GetOrdinal("Id")),
                CreatedTime = reader.GetDateTime(reader.GetOrdinal("CreatedTime")),
                PayedTime   = reader.GetDateTime(reader.GetOrdinal("PayedTime")),
                UserId      = reader.GetInt32(reader.GetOrdinal("UserId")),
                Cost        = reader.GetFloat(reader.GetOrdinal("Cost")),
                IsPayed     = reader.GetBoolean(reader.GetOrdinal("IsPayed")),
                IsRefunded  = reader.GetBoolean(reader.GetOrdinal("IsRefunded"))
            };
        }

    }
}