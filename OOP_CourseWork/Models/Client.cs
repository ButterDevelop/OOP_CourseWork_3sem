using Newtonsoft.Json;
using OOP_CourseWork.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace OOP_CourseWork.Models
{
    internal class Client : User
    {
        private string _driverLicense;
        private string _passport;
        private string _cardNumber;
        private double _balance;
        private double _sumRating;
        private int    _ordersCount;

        public Client() : base() 
        {
            _driverLicense = _passport = _cardNumber = string.Empty;
            _balance = _sumRating = 0;
            _ordersCount = 0;
        }

        public Client(int id, string username, string password, string fullname, string email, string phone,
                      string driverLicense, string passport, string cardNumber)
            : base(id, username, password, fullname, email, phone, RolesContainer.Client)
        {
            _driverLicense = driverLicense;
            _passport = passport;
            _cardNumber = cardNumber;
            _balance = 0;
            _sumRating = 0;
            _ordersCount = 0;
        }

        public Client(int id, string username, string salt, string hashedPassword, string fullname, string email, string phone, bool isAccountSetupCompleted, bool accountDeactivated,
                      string driverLicense, string passport, string cardNumber, double balance, double sumRating, int ordersCount) 
            : base(id, username, salt, hashedPassword, fullname, email, phone, RolesContainer.Client, isAccountSetupCompleted, accountDeactivated)
        {
            _driverLicense = driverLicense;
            _passport = passport;
            _cardNumber = cardNumber;
            _balance = balance;
            _sumRating = sumRating;
            _ordersCount = ordersCount;
        }

        public string DriverLicense
        {
            get
            {
                return _driverLicense;
            }
            set
            {
                _driverLicense = value;
            }
        }

        public string Passport
        {
            get
            {
                return _passport;
            }
            set
            {
                _passport = value;
            }
        }

        public string CardNumber
        {
            get
            {
                return _cardNumber;
            }
            set
            {
                _cardNumber = value;
            }
        }

        public double Balance
        {
            get
            {
                return _balance;
            }
            set
            {
                _balance = value;
            }
        }

        public double SumRating
        {
            get
            {
                return _sumRating;
            }
            set
            {
                _sumRating = value;
            }
        }

        public int OrderCount
        {
            get
            {
                return _ordersCount;
            }
            set
            {
                _ordersCount = value;
            }
        }

        [JsonIgnore]
        public double Rating
        {
            get
            {
                if (_ordersCount == 0) return 5.0;
                return _sumRating / _ordersCount;
            }
        }

        public override string ToString()
        {
            return base.ToString() + ";" + _driverLicense + ";" + _passport + ";" + _balance + ";" + _sumRating + ";" + _ordersCount;
        }

        public bool BalanceDeposit(double totalAmount, string CVV_CVC_code)
        {
            BankTransaction transaction = new BankTransaction(SaveLoadControl.BankTransactions.Count, _cardNumber, 
                                                              BankTransaction.OurOrganizationBankAccountNumber, totalAmount);
            SaveLoadControl.BankTransactions.Add(transaction);
            return BalanceDeposit(transaction, CVV_CVC_code);
        }
        public bool BalanceDeposit(BankTransaction transaction, string CVV_CVC_code)
        {
            if (transaction.Debit(CVV_CVC_code) && !BalanceIncrease(transaction.TotalAmount)) return true;
            return false;
        }

        public bool BalanceIncrease(double amount)
        {
            if ((long)_balance + amount > int.MaxValue) return false;
            _balance += amount;
            return true;
        }
        public bool BalanceDecrease(double amount)
        {
            if (_balance < amount) return false;
            _balance -= amount;
            return true;
        }
    }
}
