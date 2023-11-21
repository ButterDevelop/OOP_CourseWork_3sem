using System;

namespace OOP_CourseWork.Models
{
    public class PaymentOld
    {
        private int _id;
        private DateTime _createdTime;
        private DateTime _payedTime;
        private ClientOld _user;
        private double _cost;
        private bool _isPayed;
        private bool _isRefunded;

        public PaymentOld()
        {
            _id = 0;
            _createdTime = DateTime.UtcNow;
            _payedTime = new DateTime(1900, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            _user = new ClientOld();
            _cost = 0;
            _isPayed = false;
            _isRefunded = false;
        }

        public PaymentOld(int id, ClientOld user, double cost)
        {
            _id = id;
            _createdTime = DateTime.UtcNow;
            _payedTime = new DateTime(1900, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            _user = user;
            _cost = cost;
            _isPayed = false;
            _isRefunded = false;
        }

        public PaymentOld(int id, DateTime createdTime, DateTime payedTime, ClientOld user, double cost, bool isPayed, bool isRefunded)
        {
            _id = id;
            _createdTime = createdTime;
            _payedTime = payedTime;
            _user = user;
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

        public ClientOld User
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

    }
}
