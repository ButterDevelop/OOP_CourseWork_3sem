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
        private DateTime _orderPayedTime;
        private DateTime _orderBookingTime;
        private DateTime _orderReturnedTime;
        private DateTime _orderCancelledTime;
        private Car      _orderedCar;
        private int      _orderedHours;
        private Payment  _orderPayment;
        private bool     _isCancelled;

        public Order()
        {
            _id = 0;
            _orderCreatedTime = DateTime.Now;
            _orderPayedTime = DateTime.MinValue;
            _orderBookingTime = DateTime.MinValue;
            _orderReturnedTime = DateTime.MinValue;
            _orderCancelledTime = DateTime.MinValue;
            _orderedCar = new Car();
            _orderPayment = new Payment();
            _isCancelled = false;
        }

        public Order(int id, int paymentId, Car orderedCar, Client user, DateTime orderBookingTime, int orderedHours)
        {
            _id = id;
            _orderCreatedTime = DateTime.Now;
            _orderPayedTime = DateTime.MinValue;
            _orderBookingTime = orderBookingTime;
            _orderReturnedTime = DateTime.MinValue;
            _orderCancelledTime = DateTime.MinValue;
            _orderedCar = orderedCar;
            _orderPayment = new Payment(paymentId, user, orderedHours * orderedCar.PricePerHour);
            _isCancelled = false;
        }

        public Order(int id, Car orderedCar, DateTime orderCreatedTime, DateTime orderPayedTime, DateTime orderBookingTime, 
                     DateTime orderReturnedTime, DateTime orderCancelledTime, Payment orderPayment, bool isCancelled)
        {
            _id = id;
            _orderCreatedTime = orderCreatedTime;
            _orderPayedTime = orderPayedTime;
            _orderBookingTime = orderBookingTime;
            _orderReturnedTime = orderReturnedTime;
            _orderCancelledTime = orderCancelledTime;
            _orderedCar = orderedCar;
            _orderPayment = orderPayment;
            _isCancelled = isCancelled;
        }

        public int Id
        {
            get
            {
                return _id;
            }
        }

        public DateTime OrderCreatedTime
        {
            get
            {
                return _orderCreatedTime;
            }
        }

        public DateTime OrderPayedTime
        {
            get
            {
                return _orderPayedTime;
            }
        }

        public DateTime OrderBookingTime
        {
            get
            {
                return _orderBookingTime;
            }
        }

        public DateTime OrderReturnedTime
        {
            get
            {
                return _orderReturnedTime;
            }
        }

        public DateTime OrderCancelledTime
        {
            get
            {
                return _orderCancelledTime;
            }
        }

        public Car OrderedCar
        {
            get
            {
                return _orderedCar;
            }
        }

        public int OrderHours
        {
            get
            {
                return _orderedHours;
            }
        }

        public Payment OrderPayment
        {
            get
            {
                return _orderPayment;
            }
        }

        public bool IsCancelled
        {
            get
            {
                return _isCancelled;
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
