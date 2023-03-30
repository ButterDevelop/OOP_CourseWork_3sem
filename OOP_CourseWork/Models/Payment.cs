using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace OOP_CourseWork.Models
{
    internal class Payment
    {
        private int      _id;
        private DateTime _createdTime;
        private DateTime _payedTime;
        private Client   _user;
        private double   _cost;
        private bool     _isPayed;
        private bool     _isRefunded;

        public Payment()
        {
            _id = 0;
            _createdTime = DateTime.Now;
            _payedTime = DateTime.MinValue;
            _user = new Client();
            _cost = 0;
            _isPayed = false;
            _isRefunded = false;
        }

        public Payment(int id, Client user, double cost)
        {
            _id = id;
            _createdTime = DateTime.Now;
            _payedTime = DateTime.MinValue;
            _user = user;
            _cost = cost;
            _isPayed = false;
            _isRefunded = false;
        }

        public Payment(int id, DateTime createdTime, DateTime payedTime, Client user, double cost, bool isPayed, bool isRefunded)
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

        public Client User
        {
            get
            {
                return _user;
            }
        }

        public double Cost
        {
            get
            {
                return _cost;
            }
        }

        public bool IsPayed
        {
            get
            {
                return _isPayed;
            }
        }
    
        public bool IsRefunded
        {
            get
            {
                return _isRefunded;
            }
        }
        

        public bool Pay()
        {
            try
            {
                if (!_user.BalanceDecrease(_cost)) return false;

                _isPayed = true;

                return true;
            } catch
            {
                return false;
            }
        }

        public bool Refund()
        {
            try
            {
                if (!_user.BalanceIncrease(_cost)) return false;

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
