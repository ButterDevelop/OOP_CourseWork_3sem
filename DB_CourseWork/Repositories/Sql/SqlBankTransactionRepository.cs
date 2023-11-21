using DB_CourseWork.Interfaces;
using DB_CourseWork.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DB_CourseWork.DbRepositories.Sql
{
    public class SqlBankTransactionRepository : IBankTransactionStrategy
    {
        private readonly string _connectionString;

        public SqlBankTransactionRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<BankTransaction> GetAll()
        {
            var transactions = new List<BankTransaction>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand("SELECT * FROM BankTransactions", connection);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        transactions.Add(MapSqlReaderToObject(reader));
                    }
                }
            }
            return transactions;
        }

        public BankTransaction Get(int id)
        {
            BankTransaction transaction = null;
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand("SELECT * FROM BankTransactions WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        transaction = MapSqlReaderToObject(reader);
                    }
                }
            }
            return transaction;
        }

        public void Add(BankTransaction entity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand(@"
                INSERT INTO BankTransactions (
                    FromCardNumberOrBankAccountNumber,
                    ToCardNumberOrBankAccountNumber,
                    UserId,
                    CreatedTime,
                    PayedTime,
                    CancelledTime,
                    TotalAmount,
                    TotalTries,
                    IsFinished,
                    IsCancelled
                ) VALUES (
                    @FromCardNumberOrBankAccountNumber,
                    @ToCardNumberOrBankAccountNumber,
                    @UserId,
                    @CreatedTime,
                    @PayedTime,
                    @CancelledTime,
                    @TotalAmount,
                    @TotalTries,
                    @IsFinished,
                    @IsCancelled
                )", connection);

                command.Parameters.AddWithValue("@FromCardNumberOrBankAccountNumber", entity.FromCardNumberOrBankAccountNumber);
                command.Parameters.AddWithValue("@ToCardNumberOrBankAccountNumber",   entity.ToCardNumberOrBankAccountNumber);
                if (entity.UserId.HasValue)
                {
                    command.Parameters.AddWithValue("@UserId",                        entity.UserId.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@UserId",                        DBNull.Value);
                }
                command.Parameters.AddWithValue("@CreatedTime",                       entity.CreatedTime);
                command.Parameters.AddWithValue("@PayedTime",                         entity.PayedTime);
                command.Parameters.AddWithValue("@CancelledTime",                     entity.CancelledTime);
                command.Parameters.AddWithValue("@TotalAmount",                       entity.TotalAmount);
                command.Parameters.AddWithValue("@TotalTries",                        entity.TotalTries);
                command.Parameters.AddWithValue("@IsFinished",                        entity.IsFinished);
                command.Parameters.AddWithValue("@IsCancelled",                       entity.IsCancelled);


                command.ExecuteNonQuery();
            }
        }

        public void Update(BankTransaction entity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand(@"
                UPDATE BankTransactions SET
                    FromCardNumberOrBankAccountNumber = @FromCardNumberOrBankAccountNumber,
                    ToCardNumberOrBankAccountNumber = @ToCardNumberOrBankAccountNumber,
                    UserId = @UserId,
                    CreatedTime = @CreatedTime,
                    PayedTime = @PayedTime,
                    CancelledTime = @CancelledTime,
                    TotalAmount = @TotalAmount,
                    TotalTries = @TotalTries,
                    IsFinished = @IsFinished,
                    IsCancelled = @IsCancelled
                WHERE Id = @Id", connection);

                command.Parameters.AddWithValue("@Id",                                entity.Id);
                command.Parameters.AddWithValue("@FromCardNumberOrBankAccountNumber", entity.FromCardNumberOrBankAccountNumber);
                command.Parameters.AddWithValue("@ToCardNumberOrBankAccountNumber",   entity.ToCardNumberOrBankAccountNumber);
                if (entity.UserId.HasValue)
                {
                    command.Parameters.AddWithValue("@UserId",                        entity.UserId.Value);
                } 
                else
                {
                    command.Parameters.AddWithValue("@UserId",                        DBNull.Value);
                }
                command.Parameters.AddWithValue("@CreatedTime",                       entity.CreatedTime);
                command.Parameters.AddWithValue("@PayedTime",                         entity.PayedTime);
                command.Parameters.AddWithValue("@CancelledTime",                     entity.CancelledTime);
                command.Parameters.AddWithValue("@TotalAmount",                       entity.TotalAmount);
                command.Parameters.AddWithValue("@TotalTries",                        entity.TotalTries);
                command.Parameters.AddWithValue("@IsFinished",                        entity.IsFinished);
                command.Parameters.AddWithValue("@IsCancelled",                       entity.IsCancelled);

                command.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand("DELETE FROM BankTransactions WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);
                command.ExecuteNonQuery();
            }
        }

        public BankTransaction MapSqlReaderToObject(SqlDataReader reader)
        {
            var transaction = new BankTransaction
            {
                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                FromCardNumberOrBankAccountNumber = reader.GetString(reader.GetOrdinal("FromCardNumberOrBankAccountNumber")),
                ToCardNumberOrBankAccountNumber   = reader.GetString(reader.GetOrdinal("ToCardNumberOrBankAccountNumber")),
                UserId                            = null,
                CreatedTime                       = reader.GetDateTime(reader.GetOrdinal("CreatedTime")),
                PayedTime                         = reader.GetDateTime(reader.GetOrdinal("PayedTime")),
                CancelledTime                     = reader.GetDateTime(reader.GetOrdinal("CancelledTime")),
                TotalAmount                       = reader.GetDouble(reader.GetOrdinal("TotalAmount")),
                TotalTries                        = reader.GetInt32(reader.GetOrdinal("TotalTries")),
                IsFinished                        = reader.GetBoolean(reader.GetOrdinal("IsFinished")),
                IsCancelled                       = reader.GetBoolean(reader.GetOrdinal("IsCancelled"))
            };
            if (!reader.IsDBNull(reader.GetOrdinal("UserId")))
            {
                transaction.UserId = reader.GetInt32(reader.GetOrdinal("UserId"));
            }
            return transaction;
        }

    }
}