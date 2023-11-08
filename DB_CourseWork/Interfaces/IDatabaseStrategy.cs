using System.Collections.Generic;

namespace DB_CourseWork.Interfaces
{
    internal interface IDatabaseStrategy<T>
    {
        void Connect();

        List<T> GetAll();

        T Get(int id);

        void Add(T entity);

        void Update(T entity);

        void Delete(int id);
    }

}
