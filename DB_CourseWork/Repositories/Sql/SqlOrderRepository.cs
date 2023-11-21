using DB_CourseWork.Interfaces;
using DB_CourseWork.Models;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DB_CourseWork.DbRepositories.Sql
{
    public class SqlOrderRepository : IOrderStrategy
    {
        private readonly string _connectionString;

        public SqlOrderRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Order> GetAll()
        {
            var orders = new List<Order>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand("SELECT * FROM Orders", connection);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        orders.Add(MapSqlReaderToObject(reader));
                    }
                }
            }
            return orders;
        }

        public Order Get(int id)
        {
            Order order = null;
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand("SELECT * FROM Orders WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        order = MapSqlReaderToObject(reader);
                    }
                }
            }
            return order;
        }

        public void Add(Order entity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand(@"INSERT INTO Orders (OrderCreatedTime, OrderBookingTime, OrderCancelledTime, OrderedCarId, OrderedHours, OrderPaymentId, OrderExtendPaymentsIdsString, IsCancelled) 
                                           VALUES (@OrderCreatedTime, @OrderBookingTime, @OrderCancelledTime, @OrderedCarId, @OrderedHours, @OrderPaymentId, @OrderExtendPaymentsIdsString, @IsCancelled)", connection);
                command.Parameters.AddWithValue("@OrderCreatedTime",             entity.OrderCreatedTime);
                command.Parameters.AddWithValue("@OrderBookingTime",             entity.OrderBookingTime);
                command.Parameters.AddWithValue("@OrderCancelledTime",           entity.OrderCancelledTime);
                command.Parameters.AddWithValue("@OrderedCarId",                 entity.OrderedCarId);
                command.Parameters.AddWithValue("@OrderedHours",                 entity.OrderHours);
                command.Parameters.AddWithValue("@OrderPaymentId",               entity.OrderPaymentId);
                command.Parameters.AddWithValue("@OrderExtendPaymentsIdsString", entity.OrderExtendPaymentsIdsString);
                command.Parameters.AddWithValue("@IsCancelled",                  entity.IsCancelled);

                command.ExecuteNonQuery();
            }
        }

        public void Update(Order entity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand(@"UPDATE Orders SET 
                                            OrderCreatedTime = @OrderCreatedTime, 
                                            OrderBookingTime = @OrderBookingTime, 
                                            OrderCancelledTime = @OrderCancelledTime, 
                                            OrderedCarId = @OrderedCarId, 
                                            OrderedHours = @OrderedHours, 
                                            OrderPaymentId = @OrderPaymentId, 
                                            OrderExtendPaymentsIdsString = @OrderExtendPaymentsIdsString,
                                            IsCancelled = @IsCancelled 
                                           WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id",                           entity.Id);
                command.Parameters.AddWithValue("@OrderCreatedTime",             entity.OrderCreatedTime);
                command.Parameters.AddWithValue("@OrderBookingTime",             entity.OrderBookingTime);
                command.Parameters.AddWithValue("@OrderCancelledTime",           entity.OrderCancelledTime);
                command.Parameters.AddWithValue("@OrderedCarId",                 entity.OrderedCarId);
                command.Parameters.AddWithValue("@OrderedHours",                 entity.OrderHours);
                command.Parameters.AddWithValue("@OrderPaymentId",               entity.OrderPaymentId);
                command.Parameters.AddWithValue("@OrderExtendPaymentsIdsString", entity.OrderExtendPaymentsIdsString);
                command.Parameters.AddWithValue("@IsCancelled",                  entity.IsCancelled);

                command.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand("DELETE FROM Orders WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);
                command.ExecuteNonQuery();
            }
        }

        public Order MapSqlReaderToObject(SqlDataReader reader)
        {
            return new Order
            {
                Id                           = reader.GetInt32(reader.GetOrdinal("Id")),
                OrderCreatedTime             = reader.GetDateTime(reader.GetOrdinal("OrderCreatedTime")),
                OrderBookingTime             = reader.GetDateTime(reader.GetOrdinal("OrderBookingTime")),
                OrderCancelledTime           = reader.GetDateTime(reader.GetOrdinal("OrderCancelledTime")),
                OrderedCarId                 = reader.GetInt32(reader.GetOrdinal("OrderedCarId")),
                OrderHours                   = reader.GetInt32(reader.GetOrdinal("OrderedHours")),
                OrderPaymentId               = reader.GetInt32(reader.GetOrdinal("OrderPaymentId")),
                OrderExtendPaymentsIdsString = reader.GetString(reader.GetOrdinal("OrderExtendPaymentsIdsString")),
                IsCancelled                  = reader.GetBoolean(reader.GetOrdinal("IsCancelled"))
            };
        }

    }
}