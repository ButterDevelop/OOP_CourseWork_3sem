using DB_CourseWork.Controls;
using DB_CourseWork.Interfaces;
using DB_CourseWork.Models;
using System.Collections.Generic;

namespace DB_CourseWork.DbRepositories.Csv
{
    class CsvAdminRepository : IAdminStrategy
    {
        private static readonly string _path = Config.CSV_ADMIN_PATH;

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
