using DB_CourseWork.Interfaces;
using DB_CourseWork.Models;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DB_CourseWork.DbRepositories.Sql
{
    public class SqlCarRepository : ICarStrategy
    {
        private readonly string _connectionString;

        public SqlCarRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Car> GetAll()
        {
            var cars = new List<Car>();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand("SELECT * FROM Cars", connection);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        cars.Add(MapSqlReaderToObject(reader));
                    }
                }
            }

            return cars;
        }

        public Car Get(int id)
        {
            Car car = null;

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand("SELECT * FROM Cars WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        car = MapSqlReaderToObject(reader);
                    }
                }
            }

            return car;
        }

        public void Add(Car car)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand("INSERT INTO Cars (Brand, Model, CarLicensePlate, PricePerHour, ProductionYear, BuyTime, LastServiceTime, LocationX, LocationY, IsHidden) VALUES (@Brand, @Model, @CarLicensePlate, @PricePerHour, @ProductionYear, @BuyTime, @LastServiceTime, @LocationX, @LocationY, @IsHidden)", connection);

                command.Parameters.AddWithValue("@Brand",           car.Brand);
                command.Parameters.AddWithValue("@Model",           car.Model);
                command.Parameters.AddWithValue("@CarLicensePlate", car.CarLicensePlate);
                command.Parameters.AddWithValue("@PricePerHour",    car.PricePerHour);
                command.Parameters.AddWithValue("@ProductionYear",  car.ProductionYear);
                command.Parameters.AddWithValue("@BuyTime",         car.BuyTime);
                command.Parameters.AddWithValue("@LastServiceTime", car.LastServiceTime);
                command.Parameters.AddWithValue("@LocationX",       car.LocationX);
                command.Parameters.AddWithValue("@LocationY",       car.LocationY);
                command.Parameters.AddWithValue("@IsHidden",        car.IsHidden);

                command.ExecuteNonQuery();
            }
        }


        public void Update(Car car)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand("UPDATE Cars SET Brand = @Brand, Model = @Model, CarLicensePlate = @CarLicensePlate, PricePerHour = @PricePerHour, ProductionYear = @ProductionYear, BuyTime = @BuyTime, LastServiceTime = @LastServiceTime, LocationX = @LocationX, LocationY = @LocationY, IsHidden = @IsHidden WHERE Id = @Id", connection);

                command.Parameters.AddWithValue("@Id",              car.Id);
                command.Parameters.AddWithValue("@Brand",           car.Brand);
                command.Parameters.AddWithValue("@Model",           car.Model);
                command.Parameters.AddWithValue("@CarLicensePlate", car.CarLicensePlate);
                command.Parameters.AddWithValue("@PricePerHour",    car.PricePerHour);
                command.Parameters.AddWithValue("@ProductionYear",  car.ProductionYear);
                command.Parameters.AddWithValue("@BuyTime",         car.BuyTime);
                command.Parameters.AddWithValue("@LastServiceTime", car.LastServiceTime);
                command.Parameters.AddWithValue("@LocationX",       car.LocationX);
                command.Parameters.AddWithValue("@LocationY",       car.LocationY);
                command.Parameters.AddWithValue("@IsHidden",        car.IsHidden);

                command.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand("DELETE FROM Cars WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);

                command.ExecuteNonQuery();
            }
        }

        public Car MapSqlReaderToObject(SqlDataReader reader)
        {
            return new Car
            {
                Id              = reader.GetInt32(reader.GetOrdinal("Id")),
                Brand           = reader.GetString(reader.GetOrdinal("Brand")),
                Model           = reader.GetString(reader.GetOrdinal("Model")),
                CarLicensePlate = reader.GetString(reader.GetOrdinal("CarLicensePlate")),
                PricePerHour    = reader.GetDouble(reader.GetOrdinal("PricePerHour")),
                ProductionYear  = reader.GetDateTime(reader.GetOrdinal("ProductionYear")),
                BuyTime         = reader.GetDateTime(reader.GetOrdinal("BuyTime")),
                LastServiceTime = reader.GetDateTime(reader.GetOrdinal("LastServiceTime")),
                LocationX       = reader.GetDouble(reader.GetOrdinal("LocationX")),
                LocationY       = reader.GetDouble(reader.GetOrdinal("LocationY")),
                IsHidden        = reader.GetBoolean(reader.GetOrdinal("IsHidden"))
            };
        }

    }
}
