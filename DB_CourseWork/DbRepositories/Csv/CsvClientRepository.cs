using DB_CourseWork.Controls;
using DB_CourseWork.Interfaces;
using DB_CourseWork.Models;
using System.Collections.Generic;

namespace DB_CourseWork.DbRepositories.Csv
{
    class CsvClientRepository : IClientStrategy
    {
        private static readonly string _path = Config.CSV_CLIENT_PATH;

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
