using Newtonsoft.Json;
using OOP_CourseWork.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace OOP_CourseWork.Controls
{
    internal class SaveLoadControl
    {
        public static readonly int SaveRefreshRateMilliseconds = 1000;

        private static readonly string DBPath = "db.json";
        private static readonly string KeyPath = "enc.key";
        private static string oldDBString = "";
        private static JsonSerializerSettings settingsJSON = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
        private static byte[] EncryptionKey;
        private static byte[] EncryptionIV;

        public static List<User>            Users = new List<User>();                       //simple
        public static List<Car>             Cars = new List<Car>();                         //complicated
        public static List<Order>           Orders = new List<Order>();                     //complicated
        public static List<Payment>         Payments = new List<Payment>();                 //complicated
        public static List<BankTransaction> BankTransactions = new List<BankTransaction>(); //simple
        public static List<ServiceReport>   ServiceReports = new List<ServiceReport>();     //complicated

        public static User CurrentUser = null;

        public static void SaveWithCheck()
        {
            while (true)
            {
                string newDBString = GenerateDataForSaving();
                if (newDBString != oldDBString)
                {
                    SaveJSON();
                    oldDBString = newDBString;
                }

                Thread.Sleep(SaveRefreshRateMilliseconds);
            }
        }

        public static bool SaveJSON()
        {
            try
            {
                var json = GenerateDataForSaving();
                if (json == "-1") return false;
                File.WriteAllText(DBPath, AesGcm256.encrypt(json, EncryptionKey, EncryptionIV));

                return true;
            } catch
            {
                return false;
            }
        }

        public static string GenerateDataForSaving()
        {
            try
            {
                JSON_export.Root export = new JSON_export.Root();
                export.Users = Users;
                export.Cars = Cars;
                export.Orders = Orders;
                export.Payments = Payments;
                export.BankTransactions = BankTransactions;
                export.ServiceReports = ServiceReports;

                var json = JsonConvert.SerializeObject(export, settingsJSON);

                return json;
            }
            catch
            {
                return "-1";
            }
        }

        public static bool LoadJSON()
        {
            try
            {
                GetEncryptionKey();

                string data = File.ReadAllText(DBPath);
                oldDBString = AesGcm256.decrypt(data, EncryptionKey, EncryptionIV);
                JSON_export.Root deserialized = JsonConvert.DeserializeObject<JSON_export.Root>(oldDBString, settingsJSON);

                Users = deserialized.Users;
                Cars = deserialized.Cars;
                Orders = deserialized.Orders;
                Payments = deserialized.Payments;
                BankTransactions = deserialized.BankTransactions;
                ServiceReports = deserialized.ServiceReports;

                // Исправляем проблему дублирования. Присваиваем объекты из массива, новосозданные (дублированные) объекты удаляются.
                foreach (var a in Orders)
                {
                    a.OrderedCar = Cars[a.OrderedCar.Id];
                    a.OrderPayment = Payments[a.OrderPayment.Id];
                }
                foreach (var a in Payments)
                {
                    a.User = (Client)Users[a.User.Id];
                }
                foreach (var a in ServiceReports)
                {
                    a.ServicedCar = Cars[a.ServicedCar.Id];
                }

                return true;
            } catch
            {
                return false;
            }
        }

        public static bool GetEncryptionKey()
        {
            if (!File.Exists(DBPath)) File.WriteAllText(DBPath, "");
            if (!File.Exists(KeyPath) || !File.Exists(DBPath)) return false;

            var lines = File.ReadAllLines(KeyPath);

            if (lines.Length != 2) return false;

            var key = Convert.FromBase64String(lines[0]);
            var iv = Convert.FromBase64String(lines[1]);

            if (key.Length != AesGcm256.KeyBitSize / 8 && iv.Length != AesGcm256.NonceBitSize / 8) return false;

            EncryptionKey = key;
            EncryptionIV = iv;

            return true;
        }

        public static void CreateKeys()
        {
            File.WriteAllText(KeyPath, Convert.ToBase64String(AesGcm256.NewKey()) + Environment.NewLine);
            File.AppendAllText(KeyPath, Convert.ToBase64String(AesGcm256.NewIv()));
        }
    }
}
