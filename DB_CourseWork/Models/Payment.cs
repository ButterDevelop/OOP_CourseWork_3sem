using DB_CourseWork.Controls;
using System;

namespace DB_CourseWork.Models
{
    public class Payment
    {
        private int      _id;
        private DateTime _createdTime;
        private DateTime _payedTime;
        private int      _userId;
        private double   _cost;
        private bool     _isPayed;
        private bool     _isRefunded;

        public Payment()
        {
            _id = 0;
            _createdTime = DateTime.UtcNow;
            _payedTime = new DateTime(1900, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            _userId = 0;
            _cost = 0;
            _isPayed = false;
            _isRefunded = false;
        }

        public Payment(Client user, double cost)
        {
            _id = 0;
            _createdTime = DateTime.UtcNow;
            _payedTime = new DateTime(1900, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            _userId = user.Id;
            _cost = cost;
            _isPayed = false;
            _isRefunded = false;
        }

        public Payment(DateTime createdTime, DateTime payedTime, Client user, double cost, bool isPayed, bool isRefunded)
        {
            _id = 0;
            _createdTime = createdTime;
            _payedTime = payedTime;
            _userId = user.Id;
            _cost = cost;
            _isPayed = isPayed;
            _isRefunded = isRefunded;
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

        public double Cost
        {
            get
            {
                return _cost;
            }
            set
            {
                _cost = value;
            }
        }

        public bool IsPayed
        {
            get
            {
                return _isPayed;
            }
            set
            {
                _isPayed = value;
            }
        }
    
        public bool IsRefunded
        {
            get
            {
                return _isRefunded;
            }
            set
            {
                _isRefunded = value;
            }
        }
        

        public bool Pay()
        {
            try
            {
                var user = DatabaseContext.DbContext.Clients.Get(_userId);
                var result = user.BalanceDecrease(_cost);
                DatabaseContext.DbContext.Clients.Update(user);
                if (!result) return false;

                _isPayed = true;

                return true;
            } 
            catch
            {
                return false;
            }
        }

        public bool Refund()
        {
            try
            {
                var user = DatabaseContext.DbContext.Clients.Get(_userId);
                var result = user.BalanceIncrease(_cost);
                DatabaseContext.DbContext.Clients.Update(user);
                if (!result) return false;

                _isRefunded = true;

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
