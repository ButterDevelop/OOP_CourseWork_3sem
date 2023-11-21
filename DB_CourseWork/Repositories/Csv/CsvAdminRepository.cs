using DB_CourseWork.Controls;
using DB_CourseWork.Interfaces;
using DB_CourseWork.Models;
using System.Collections.Generic;
using System.Linq;

namespace DB_CourseWork.DbRepositories.Csv
{
    public class CsvAdminRepository : IAdminStrategy
    {
        private string _path = Config.CSV_ADMIN_PATH;

        public CsvAdminRepository(string path = null)
        {
            if (path != null) _path = path;
        }

        public void Connect() { }

        public List<Admin> GetAll()
        {
            return CsvSerializer.ReadFromFile<Admin>(_path);
        }

        public Admin Get(int id)
        {
            return CsvSerializer.ReadFromFile<Admin>(_path).Find(admin => admin.Id == id);
        }

        public void Add(Admin entity)
        {
            var admins = GetAll();
            if (entity.Id == 0 || admins.FirstOrDefault(r => r.Id == entity.Id) != null)
            {
                if (admins.Count > 0)
                {
                    entity.Id = admins.Max(r => r.Id) + 1;
                }
                else
                {
                    entity.Id = 1;
                }
            }
            admins.Add(entity);
            CsvSerializer.WriteToFile(_path, admins);
        }

        public void Update(Admin entity)
        {
            var admins = GetAll();
            int index = admins.FindIndex(admin => admin.Id == entity.Id);
            if (index != -1)
            {
                admins[index] = entity;
                CsvSerializer.WriteToFile(_path, admins);
            }
        }

        public void Delete(int id)
        {
            var admins = GetAll();
            admins.RemoveAll(admin => admin.Id == id);
            CsvSerializer.WriteToFile(_path, admins);
        }
    }

}
