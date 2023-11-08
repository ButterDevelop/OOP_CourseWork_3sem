using System;

namespace DB_CourseWork.Models
{
    internal class BankTransaction
    {
        public static readonly string ServiceCentreBankAccountNumber = "BY20 OLMP 3135 0000 0010 0000 0933";
        public static readonly string OurOrganizationBankAccountNumber = "BY20 OLMP 3136 0000 0020 0010 9045";
        public static readonly string OurOrganizationSecretCode = "045";
        public static readonly int TransactionTries = 3;
        public static readonly int MinutesForTransaction = 15;

        private int      _id;
        private string   _fromCardNumberOrBankAccountNumber;
        private string   _toCardNumberOrBankAccountNumber;
        private int      _userId;
        private DateTime _createdTime;
        private DateTime _payedTime;
        private DateTime _cancelledTime;
        private double   _totalAmount;
        private int      _totalTries;   
        private bool     _isFinished;
        private bool     _isCancelled;

        public BankTransaction()
        {
            _id = -1;
            _fromCardNumberOrBankAccountNumber = _toCardNumberOrBankAccountNumber = string.Empty;
            _createdTime = DateTime.Now;
            _payedTime = DateTime.MinValue;
            _cancelledTime = DateTime.MinValue;
            _totalAmount = 0;
            _totalTries = 0;
            _isFinished = false;
            _isCancelled = false;
        }

        public BankTransaction(string fromCardNumberOrBankAccountNumber, string toCardNumberOrBankAccountNumber, double totalAmount, User user)
        {
            _id = -1;
            _fromCardNumberOrBankAccountNumber = fromCardNumberOrBankAccountNumber;
            _toCardNumberOrBankAccountNumber = toCardNumberOrBankAccountNumber;
            _userId = user.Id;
            _createdTime = DateTime.Now;
            _payedTime = DateTime.MinValue;
            _cancelledTime = DateTime.MinValue;
            _totalAmount = totalAmount;
            _totalTries = 0;
            _isFinished = false;
            _isCancelled = false;
        }

        public BankTransaction(string fromCardNumberOrBankAccountNumber, string toCardNumberOrBankAccountNumber, User user, DateTime createdTime, 
                               DateTime payedTime, DateTime cancelledTime, double totalAmount, int totalTries, bool isPayed, bool isCancelled)
        {
            _id = -1;
            _fromCardNumberOrBankAccountNumber = fromCardNumberOrBankAccountNumber;
            _toCardNumberOrBankAccountNumber = toCardNumberOrBankAccountNumber;
            _userId = user.Id;
            _createdTime = createdTime;
            _payedTime = payedTime;
            _cancelledTime = cancelledTime;
            _totalAmount = totalAmount;
            _totalTries = totalTries;
            _isFinished = isPayed;
            _isCancelled = isCancelled;
        }

        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        public string FromCardNumberOrBankAccountNumber
        {
            get
            {
                return _fromCardNumberOrBankAccountNumber;
            }
            set
            {
                _fromCardNumberOrBankAccountNumber = value;
            }
        }

        public string ToCardNumberOrBankAccountNumber
        {
            get
            {
                return _toCardNumberOrBankAccountNumber;
            }
            set
            {
                _toCardNumberOrBankAccountNumber = value;
            }
        }

        public int UserId
        {
            get
            {
                return _userId;
            }
            set
            {
                _userId = value;
            }
        }

        public DateTime CreatedTime
        {
            get
            {
                return _createdTime;
            }
            set
            {
                _createdTime = value;
            }
        }

        public DateTime PayedTime
        {
            get
            {
                return _payedTime;
            }
            set
            {
                _payedTime = value;
            }
        }

        public DateTime CancelledTime
        {
            get
            {
                return _cancelledTime;
            }
            set
            {
                _cancelledTime = value;
            }
        }

        public double TotalAmount
        {
            get
            {
                return _totalAmount;
            }
            set
            {
                _totalAmount = value;
            }
        }

        public int TotalTries
        {
            get
            {
                return _totalTries;
            }
            set
            {
                _totalTries = value;
            }
        }

        public bool IsFinished
        {
            get
            {
                return _isFinished;
            }
            set
            {
                _isFinished = value;
            }
        }

        public bool IsCancelled
        {
            get
            {
                return _isCancelled;
            }
            set
            {
                _isCancelled = value;
            }
        }


        // Симуляция запроса в банк. В зависимости от адреса выходящего и входящего будем понимать, пришли или ушли деньги относительно нашего счёта
        public bool Debit(string secretCode)
        {
            if (DateTime.Now >= _createdTime.AddMinutes(MinutesForTransaction))
            {
                Cancel();
                return false;
            }

            if (++_totalTries > TransactionTries)
            {
                Cancel(); 
                return false;
            }

            if (_isFinished) return false;

            if (_fromCardNumberOrBankAccountNumber.Substring(_fromCardNumberOrBankAccountNumber.Length - 3) != secretCode) return false;

            _payedTime = DateTime.Now;
            _isFinished = true;

            return true;
        }

        public bool Cancel()
        {
            if (_isCancelled) return false;

            _cancelledTime = DateTime.Now;
            _isCancelled = true;

            return true;
        }
    }
}
