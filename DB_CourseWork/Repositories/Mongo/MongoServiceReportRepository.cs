using DB_CourseWork.Controls;
using DB_CourseWork.Interfaces;
using DB_CourseWork.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace DB_CourseWork.DbRepositories.Mongo
{
    public class MongoServiceReportRepository : IServiceReportStrategy
    {
        private readonly IMongoCollection<ServiceReport> _serviceReports;

        public MongoServiceReportRepository(string connectionString, string databaseName)
        {
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(databaseName);
            _serviceReports = database.GetCollection<ServiceReport>(Config.MONGO_SERVICE_REPORT_PATH);
        }

        public List<ServiceReport> GetAll()
        {
            return _serviceReports.Find(report => true).ToList();
        }

        public ServiceReport Get(int id)
        {
            return _serviceReports.Find(report => report.Id == id).FirstOrDefault();
        }

        public void Add(ServiceReport report)
        {
            if (report.Id == 0 || Get(report.Id) != null)
            {
                var entities = GetAll();
                if (entities.Count > 0)
                {
                    report.Id = entities.Max(r => r.Id) + 1;
                }
                else
                {
                    report.Id = 1;
                }
            }

            _serviceReports.InsertOne(report);
        }

        public void Update(ServiceReport report)
        {
            _serviceReports.ReplaceOne(existingReport => existingReport.Id == report.Id, report);
        }

        public void Delete(int id)
        {
            _serviceReports.DeleteOne(report => report.Id == id);
        }
    }
}
