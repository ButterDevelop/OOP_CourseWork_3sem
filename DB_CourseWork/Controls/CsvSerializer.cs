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
            if (!File.Exists(path))
            {
                using (var fs = new FileStream(path, FileMode.CreateNew, FileAccess.Write, FileShare.None, 4096, FileOptions.None))
                {
                }
            }
            using (var writer = new StreamWriter(path))
            {
                using (var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture)))
                {
                    csv.WriteRecords(records);
                }
            }
        }

        public static List<T> ReadFromFile<T>(string path)
        {
            if (!File.Exists(path))
            {
                using (var fs = new FileStream(path, FileMode.CreateNew, FileAccess.Write, FileShare.None, 4096, FileOptions.None))
                {
                }
            }
            using (var reader = new StreamReader(path))
            {
                using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
                {
                    return new List<T>(csv.GetRecords<T>());
                }
            }
        }
    }
}
