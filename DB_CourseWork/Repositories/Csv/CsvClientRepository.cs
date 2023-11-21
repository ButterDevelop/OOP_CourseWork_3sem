using DB_CourseWork.Controls;
using DB_CourseWork.Interfaces;
using DB_CourseWork.Models;
using System.Collections.Generic;
using System.Linq;

namespace DB_CourseWork.DbRepositories.Csv
{
    public class CsvClientRepository : IClientStrategy
    {
        private string _path = Config.CSV_CLIENT_PATH;

        public CsvClientRepository(string path = null)
        {
            if (path != null) _path = path;
        }

        public void Connect() { }

        public List<Client> GetAll()
        {
            return CsvSerializer.ReadFromFile<Client>(_path);
        }

        public Client Get(int id)
        {
            return CsvSerializer.ReadFromFile<Client>(_path).Find(client => client.Id == id);
        }

        public void Add(Client entity)
        {
            var clients = GetAll();
            if (entity.Id == 0 || clients.FirstOrDefault(r => r.Id == entity.Id) != null)
            {
                if (clients.Count > 0)
                {
                    entity.Id = clients.Max(r => r.Id) + 1;
                }
                else
                {
                    entity.Id = 1;
                }
            }
            clients.Add(entity);
            CsvSerializer.WriteToFile(_path, clients);
        }

        public void Update(Client entity)
        {
            var clients = GetAll();
            int index = clients.FindIndex(client => client.Id == entity.Id);
            if (index != -1)
            {
                clients[index] = entity;
                CsvSerializer.WriteToFile(_path, clients);
            }
        }

        public void Delete(int id)
        {
            var clients = GetAll();
            clients.RemoveAll(client => client.Id == id);
            CsvSerializer.WriteToFile(_path, clients);
        }
    }

}
