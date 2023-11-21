using DB_CourseWork.Interfaces;
using DB_CourseWork.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DB_CourseWork.DbRepositories.Sql
{
    public class SqlServiceReportRepository : IServiceReportStrategy
    {
        private readonly string _connectionString;

        public SqlServiceReportRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<ServiceReport> GetAll()
        {
            var reports = new List<ServiceReport>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand("SELECT * FROM ServiceReports", connection);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var report = MapSqlReaderToObject(reader);
                        reports.Add(report);
                    }
                }
            }
            return reports;
        }

        public ServiceReport Get(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand("SELECT * FROM ServiceReports WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return MapSqlReaderToObject(reader);
                    }
                }
            }
            return null;
        }

        public void Add(ServiceReport report)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand(
                    @"INSERT INTO ServiceReports 
                    (Description, StartedDate, FinishedDate, AdditionalCost, IsStarted, IsFinished, PlannedCompletionDays, WorkerId, ServicedCarId, EmployeeReport) 
                    VALUES 
                    (@Description, @StartedDate, @FinishedDate, @AdditionalCost, @IsStarted, @IsFinished, @PlannedCompletionDays, @WorkerId, @ServicedCarId, @EmployeeReport)",
                    connection);

                // Заполняем параметры команды
                command.Parameters.AddWithValue("@Description",           report.Description);
                command.Parameters.AddWithValue("@StartedDate",           report.StartedDate);
                command.Parameters.AddWithValue("@FinishedDate",          report.FinishedDate);
                command.Parameters.AddWithValue("@AdditionalCost",        report.AdditionalCost);
                command.Parameters.AddWithValue("@IsStarted",             report.IsStarted);
                command.Parameters.AddWithValue("@IsFinished",            report.IsFinished);
                command.Parameters.AddWithValue("@PlannedCompletionDays", report.PlannedCompletionDays);
                if (report.WorkerId.HasValue)
                {
                    command.Parameters.AddWithValue("@WorkerId",          report.WorkerId.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@WorkerId",          DBNull.Value);
                }
                command.Parameters.AddWithValue("@ServicedCarId",         report.ServicedCarId);
                command.Parameters.AddWithValue("@EmployeeReport",        report.EmployeeReport);

                command.ExecuteNonQuery();
            }
        }

        public void Update(ServiceReport report)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand(
                    "UPDATE ServiceReports SET Description = @Description, StartedDate = @StartedDate, FinishedDate = @FinishedDate, AdditionalCost = @AdditionalCost, IsStarted = @IsStarted, IsFinished = @IsFinished, PlannedCompletionDays = @PlannedCompletionDays, WorkerId = @WorkerId, ServicedCarId = @ServicedCarId, EmployeeReport = @EmployeeReport WHERE Id = @Id",
                    connection);

                command.Parameters.AddWithValue("@Id",                    report.Id);
                command.Parameters.AddWithValue("@Description",           report.Description);
                command.Parameters.AddWithValue("@StartedDate",           report.StartedDate);
                command.Parameters.AddWithValue("@FinishedDate",          report.FinishedDate);
                command.Parameters.AddWithValue("@AdditionalCost",        report.AdditionalCost);
                command.Parameters.AddWithValue("@IsStarted",             report.IsStarted);
                command.Parameters.AddWithValue("@IsFinished",            report.IsFinished);
                command.Parameters.AddWithValue("@PlannedCompletionDays", report.PlannedCompletionDays);
                if (report.WorkerId.HasValue)
                {
                    command.Parameters.AddWithValue("@WorkerId",          report.WorkerId.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@WorkerId",          DBNull.Value);
                }
                command.Parameters.AddWithValue("@ServicedCarId",         report.ServicedCarId);
                command.Parameters.AddWithValue("@EmployeeReport",        report.EmployeeReport);

                command.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand("DELETE FROM ServiceReports WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);
                command.ExecuteNonQuery();
            }
        }

        public ServiceReport MapSqlReaderToObject(SqlDataReader reader)
        {
            var report = new ServiceReport
            {
                Id =                    reader.GetInt32(reader.GetOrdinal("Id")),
                Description =           reader.GetString(reader.GetOrdinal("Description")),
                StartedDate =           reader.GetDateTime(reader.GetOrdinal("StartedDate")),
                FinishedDate =          reader.GetDateTime(reader.GetOrdinal("FinishedDate")),
                AdditionalCost =        reader.GetDouble(reader.GetOrdinal("AdditionalCost")),
                IsStarted =             reader.GetBoolean(reader.GetOrdinal("IsStarted")),
                IsFinished =            reader.GetBoolean(reader.GetOrdinal("IsFinished")),
                PlannedCompletionDays = reader.GetInt32(reader.GetOrdinal("PlannedCompletionDays")),
                WorkerId =              null,
                ServicedCarId =         reader.GetInt32(reader.GetOrdinal("ServicedCarId")),
                EmployeeReport =        reader.GetString(reader.GetOrdinal("EmployeeReport"))
            };
            if (!reader.IsDBNull(reader.GetOrdinal("WorkerId")))
            {
                report.WorkerId = reader.GetInt32(reader.GetOrdinal("WorkerId"));
            }
            return report;
        }

    }
}
