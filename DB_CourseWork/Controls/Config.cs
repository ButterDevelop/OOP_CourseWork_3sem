using Microsoft.Extensions.Configuration;
using System.IO;

namespace DB_CourseWork.Controls
{
    class Config
    {
        private static IConfiguration _configuration;

        static Config()
        {
            // Билдер конфигураций
            var builder = new ConfigurationBuilder()
                              .SetBasePath(Directory.GetCurrentDirectory())
                              .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            _configuration = builder.Build();
        }

        // CSV PART
        public static string CSV_CLIENT_PATH =>             _configuration["FilePaths:CSV_CLIENT_PATH"];
        public static string CSV_EMPLOYEE_PATH =>           _configuration["FilePaths:CSV_EMPLOYEE_PATH"];
        public static string CSV_ADMIN_PATH =>              _configuration["FilePaths:CSV_ADMIN_PATH"];
        public static string CSV_CAR_PATH =>                _configuration["FilePaths:CSV_CAR_PATH"];
        public static string CSV_ORDER_PATH =>              _configuration["FilePaths:CSV_ORDER_PATH"];
        public static string CSV_PAYMENT_PATH =>            _configuration["FilePaths:CSV_PAYMENT_PATH"];
        public static string CSV_BANK_TRANSACTION_PATH =>   _configuration["FilePaths:CSV_BANK_TRANSACTION_PATH"];
        public static string CSV_SERVICE_REPORT_PATH =>     _configuration["FilePaths:CSV_SERVICE_REPORT_PATH"];

        // MONGO PART
        public static string MONGO_CONNECTION_STRING =>     _configuration["ConnectionStrings:MongoConnectionString"];
        public static string MONGO_DATABASE_NAME =>         _configuration["ConnectionStrings:MongoDatabaseName"];
        public static string MONGO_TEST_DATABASE_NAME =>    _configuration["ConnectionStrings:MongoTestDatabaseName"];
        public static string MONGO_CLIENT_PATH =>           _configuration["MongoTableNames:MONGO_CLIENT_PATH"];
        public static string MONGO_EMPLOYEE_PATH =>         _configuration["MongoTableNames:MONGO_EMPLOYEE_PATH"];
        public static string MONGO_ADMIN_PATH =>            _configuration["MongoTableNames:MONGO_ADMIN_PATH"];
        public static string MONGO_CAR_PATH =>              _configuration["MongoTableNames:MONGO_CAR_PATH"];
        public static string MONGO_ORDER_PATH =>            _configuration["MongoTableNames:MONGO_ORDER_PATH"];
        public static string MONGO_PAYMENT_PATH =>          _configuration["MongoTableNames:MONGO_PAYMENT_PATH"];
        public static string MONGO_BANK_TRANSACTION_PATH => _configuration["MongoTableNames:MONGO_BANK_TRANSACTION_PATH"];
        public static string MONGO_SERVICE_REPORT_PATH =>   _configuration["MongoTableNames:MONGO_SERVICE_REPORT_PATH"];

        // SQL PART
        public static string SQL_CONNECTION_STRING =>       _configuration["ConnectionStrings:SqlConnectionString"];
    }
}
