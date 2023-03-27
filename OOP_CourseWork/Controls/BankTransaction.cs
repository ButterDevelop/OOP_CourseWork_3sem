using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace OOP_CourseWork.Controls
{
    internal class BankTransaction
    {
        public static readonly int TransactionTries = 3;
        public static readonly int MinutesForTransaction = 15;

        private string   _cardNumber;
        private DateTime _createdTime;
        private DateTime _payedTime;
        private DateTime _cancelledTime;
        private double   _totalAmount;
        private int      _totalTries;
        private bool     _isPayed;
        private bool     _isCancelled;

        public BankTransaction()
        {
            _cardNumber = string.Empty;
            _createdTime = DateTime.Now;
            _payedTime = DateTime.MinValue;
            _cancelledTime = DateTime.MinValue;
            _totalAmount = 0;
            _totalTries = 0;
            _isPayed = false;
            _isCancelled = false;
        }

        public BankTransaction(string cardNumber, double totalAmount)
        {
            _cardNumber = cardNumber;
            _createdTime = DateTime.Now;
            _payedTime = DateTime.MinValue;
            _cancelledTime = DateTime.MinValue;
            _totalAmount = totalAmount;
            _totalTries = 0;
            _isPayed = false;
            _isCancelled = false;
        }

        public BankTransaction(string cardNumber, DateTime createdTime, DateTime payedTime, DateTime cancelledTime, double totalAmount, int totalTries, bool isPayed, bool isCancelled)
        {
            _cardNumber = cardNumber;
            _createdTime = createdTime;
            _payedTime = payedTime;
            _cancelledTime = cancelledTime;
            _totalAmount = totalAmount;
            _totalTries = totalTries;
            _isPayed = isPayed;
            _isCancelled = isCancelled;
        }

        public string CardNumber
        {
            get
            {
                return _cardNumber;
            }
        }

        public DateTime CreatedTime
        {
            get
            {
                return _createdTime;
            }
        }

        public DateTime PayedTime
        {
            get
            {
                return _payedTime;
            }
        }

        public DateTime CancelledTime
        {
            get
            {
                return _cancelledTime;
            }
        }

        public double TotalAmount
        {
            get
            {
                return _totalAmount;
            }
        }

        public int TotalTries
        {
            get
            {
                return _totalTries;
            }
        }

        public bool IsPayed
        {
            get
            {
                return _isPayed;
            }
        }

        public bool IsCancelled
        {
            get
            {
                return _isCancelled;
            }
        }


        // Симуляция запроса в банк
        public bool Debit(string CVV_CVC_code)
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

            if (_isPayed) return false;

            if (_cardNumber.Substring(_cardNumber.Length - 3) != CVV_CVC_code) return false;

            _payedTime = DateTime.Now;
            _isPayed = true;

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
