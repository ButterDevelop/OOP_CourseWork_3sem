using OOP_CourseWork.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_CourseWork.Models
{
    internal class Order
    {
        private int      _id;
        private DateTime _orderCreatedTime;
        private DateTime _orderBookingTime;
        private DateTime _orderCancelledTime;
        private Car      _orderedCar;
        private int      _orderedHours;
        private Payment  _orderPayment;
        private bool     _isCancelled;

        public Order()
        {
            _id = 0;
            _orderCreatedTime = DateTime.Now;
            _orderBookingTime = DateTime.MaxValue;
            _orderCancelledTime = DateTime.MaxValue;
            _orderedHours = 0;
            _orderedCar = new Car();
            _orderPayment = new Payment();
            _isCancelled = false;
        }

        public Order(int id, Payment payment, Car orderedCar, Client user, DateTime orderBookingTime, int orderedHours)
        {
            _id = id;
            _orderCreatedTime = DateTime.Now;
            _orderBookingTime = orderBookingTime;
            _orderCancelledTime = DateTime.MaxValue;
            _orderedCar = orderedCar;
            _orderedHours = orderedHours;
            _orderPayment = payment;
            SaveLoadControl.Payments.Add(_orderPayment);
            _isCancelled = false;
        }

        public Order(int id, Car orderedCar, Client user, DateTime orderBookingTime, int orderedHours)
        {
            _id = id;
            _orderCreatedTime = DateTime.Now;
            _orderBookingTime = orderBookingTime;
            _orderCancelledTime = DateTime.MaxValue;
            _orderedCar = orderedCar;
            _orderedHours = orderedHours;
            _orderPayment = new Payment(SaveLoadControl.Payments.Count, user, orderedHours * orderedCar.PricePerHour);
            SaveLoadControl.Payments.Add(_orderPayment);
            _isCancelled = false;
        }

        public Order(int id, Car orderedCar, DateTime orderCreatedTime, DateTime orderBookingTime, 
                     DateTime orderCancelledTime, Payment orderPayment, int orderedHours, bool isCancelled)
        {
            _id = id;
            _orderCreatedTime = orderCreatedTime;
            _orderBookingTime = orderBookingTime;
            _orderCancelledTime = orderCancelledTime;
            _orderedCar = orderedCar;
            _orderPayment = orderPayment;
            _orderedHours = orderedHours;
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

        public DateTime OrderCreatedTime
        {
            get
            {
                return _orderCreatedTime;
            }
            set
            {
                _orderCreatedTime = value;
            }
        }

        public DateTime OrderBookingTime
        {
            get
            {
                return _orderBookingTime;
            }
            set
            {
                _orderBookingTime = value;
            }
        }

        public DateTime OrderCancelledTime
        {
            get
            {
                return _orderCancelledTime;
            }
            set
            {
                _orderCancelledTime = value;
            }
        }

        public Car OrderedCar
        {
            get
            {
                return _orderedCar;
            }
            set
            {
                _orderedCar = value;
            }
        }

        public int OrderHours
        {
            get
            {
                return _orderedHours;
            }
            set
            {
                _orderedHours = value;
            }
        }

        public Payment OrderPayment
        {
            get
            {
                return _orderPayment;
            }
            set
            {
                _orderPayment = value;
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


        public bool Cancel()
        {
            if (DateTime.Now >= _orderBookingTime) return false;

            if (_orderPayment.IsPayed) _orderPayment.Refund();

            _orderCancelledTime = DateTime.Now;
            _isCancelled = true;

            return true;
        }
    }
}
