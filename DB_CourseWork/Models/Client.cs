using Newtonsoft.Json;
using DB_CourseWork.Controls;

namespace DB_CourseWork.Models
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

        public Client(string username, string password, string fullname, string email, string phone)
            : base(username, password, fullname, email, phone, RolesContainer.Client)
        {
            _driverLicense = _passport = _cardNumber = string.Empty;
            _balance = 0;
            _sumRating = 0;
            _ordersCount = 0;
        }

        public Client(User user) : base(user.UserName, user.Salt, user.HashedPassword, user.FullName, user.Email,
                                   user.Phone, RolesContainer.Client, user.IsAccountSetupCompleted, user.AccountDeactivated)
        {
            _driverLicense = _passport = _cardNumber = string.Empty;
            _balance = 0;
            _sumRating = 0;
            _ordersCount = 0;
        }

        public Client(string username, string password, string fullname, string email, string phone,
                      string driverLicense, string passport, string cardNumber)
            : base(username, password, fullname, email, phone, RolesContainer.Client)
        {
            _driverLicense = driverLicense;
            _passport = passport;
            _cardNumber = cardNumber;
            _balance = 0;
            _sumRating = 0;
            _ordersCount = 0;
        }

        public Client(string username, string salt, string hashedPassword, string fullname, string email, string phone, bool isAccountSetupCompleted, bool accountDeactivated,
                      string driverLicense, string passport, string cardNumber, double balance, double sumRating, int ordersCount) 
            : base(username, salt, hashedPassword, fullname, email, phone, RolesContainer.Client, isAccountSetupCompleted, accountDeactivated)
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
            BankTransaction transaction = new BankTransaction(_cardNumber, BankTransaction.OurOrganizationBankAccountNumber, totalAmount, this);
            DatabaseContext.DbContext.BankTransactions.Add(transaction);

            bool result = BalanceDeposit(transaction, CVV_CVC_code);
            if (!result) transaction.Cancel();

            return result;
        }
        public bool BalanceDeposit(BankTransaction transaction, string CVV_CVC_code)
        {
            if (transaction.Debit(CVV_CVC_code) && BalanceIncrease(transaction.TotalAmount)) return true;
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

        public bool ChangeSettings(string password, string driverLicense, string passport, string cardNumber)
        {
            if (IsPasswordCorrect(password))
            {
                _driverLicense = driverLicense;
                _passport = passport;
                _cardNumber = cardNumber;

                return true;
            }
            return false;
        }
    }
}
