using System;

namespace OOP_CourseWork.Models
{
    public class BankTransactionOld
    {
        public static readonly string ServiceCentreBankAccountNumber = "BY20 OLMP 3135 0000 0010 0000 0933";
        public static readonly string OurOrganizationBankAccountNumber = "BY20 OLMP 3136 0000 0020 0010 9045";
        public static readonly string OurOrganizationSecretCode = "045";
        public static readonly int TransactionTries = 3;
        public static readonly int MinutesForTransaction = 15;

        private int      _id;
        private string   _fromCardNumberOrBankAccountNumber;
        private string   _toCardNumberOrBankAccountNumber;
        private UserOld     _user;
        private DateTime _createdTime;
        private DateTime _payedTime;
        private DateTime _cancelledTime;
        private double   _totalAmount;
        private int      _totalTries;   
        private bool     _isFinished;
        private bool     _isCancelled;

        public BankTransactionOld()
        {
            _id = 0;
            _fromCardNumberOrBankAccountNumber = _toCardNumberOrBankAccountNumber = string.Empty;
            _createdTime = DateTime.UtcNow;
            _payedTime = new DateTime(1900, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            _cancelledTime = new DateTime(1900, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            _totalAmount = 0;
            _totalTries = 0;
            _isFinished = false;
            _isCancelled = false;
        }

        public BankTransactionOld(string fromCardNumberOrBankAccountNumber, string toCardNumberOrBankAccountNumber, double totalAmount, UserOld user)
        {
            _id = 0;
            _fromCardNumberOrBankAccountNumber = fromCardNumberOrBankAccountNumber;
            _toCardNumberOrBankAccountNumber = toCardNumberOrBankAccountNumber;
            _user = user;
            _createdTime = DateTime.UtcNow;
            _payedTime = new DateTime(1900, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            _cancelledTime = new DateTime(1900, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            _totalAmount = totalAmount;
            _totalTries = 0;
            _isFinished = false;
            _isCancelled = false;
        }

        public BankTransactionOld(string fromCardNumberOrBankAccountNumber, string toCardNumberOrBankAccountNumber, UserOld user, DateTime createdTime, 
                               DateTime payedTime, DateTime cancelledTime, double totalAmount, int totalTries, bool isPayed, bool isCancelled)
        {
            _id = 0;
            _fromCardNumberOrBankAccountNumber = fromCardNumberOrBankAccountNumber;
            _toCardNumberOrBankAccountNumber = toCardNumberOrBankAccountNumber;
            _user = user;
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

        public UserOld User
        {
            get
            {
                return _user;
            }
            set
            {
                _user = value;
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

    }
}
