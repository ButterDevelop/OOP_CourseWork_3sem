using DB_CourseWork.Controls;
using DB_CourseWork.Interfaces;
using DB_CourseWork.Models;
using System.Collections.Generic;
using System.Linq;

namespace DB_CourseWork.DbRepositories.Csv
{
    public class CsvServiceReportRepository : IServiceReportStrategy
    {
        private string _path = Config.CSV_SERVICE_REPORT_PATH;

        public CsvServiceReportRepository(string path = null)
        {
            if (path != null) _path = path;
        }

        public void Connect() { }

        public List<ServiceReport> GetAll()
        {
            return CsvSerializer.ReadFromFile<ServiceReport>(_path);
        }

        public ServiceReport Get(int id)
        {
            return CsvSerializer.ReadFromFile<ServiceReport>(_path).Find(serviceReport => serviceReport.Id == id);
        }

        public void Add(ServiceReport entity)
        {
            var serviceReports = GetAll();
            if (entity.Id == 0 || serviceReports.FirstOrDefault(r => r.Id == entity.Id) != null)
            {
                if (serviceReports.Count > 0)
                {
                    entity.Id = serviceReports.Max(r => r.Id) + 1;
                }
                else
                {
                    entity.Id = 1;
                }
            }
            serviceReports.Add(entity);
            CsvSerializer.WriteToFile(_path, serviceReports);
        }

        public void Update(ServiceReport entity)
        {
            var serviceReports = GetAll();
            int index = serviceReports.FindIndex(serviceReport => serviceReport.Id == entity.Id);
            if (index != -1)
            {
                serviceReports[index] = entity;
                CsvSerializer.WriteToFile(_path, serviceReports);
            }
        }

        public void Delete(int id)
        {
            var serviceReports = GetAll();
            serviceReports.RemoveAll(serviceReport => serviceReport.Id == id);
            CsvSerializer.WriteToFile(_path, serviceReports);
        }
    }

}
