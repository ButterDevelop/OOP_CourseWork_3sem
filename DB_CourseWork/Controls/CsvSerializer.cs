using CsvHelper;
using CsvHelper.Configuration;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace DB_CourseWork.Controls
{
    public static class CsvSerializer
    {
        public static void WriteToFile<T>(string path, IEnumerable<T> records)
        {
            var writer = new StreamWriter(path);
            var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture));
            csv.WriteRecords(records);
        }

        public static List<T> ReadFromFile<T>(string path)
        {
            var reader = new StreamReader(path);
            var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture));
            return new List<T>(csv.GetRecords<T>());
        }
    }
}
