using DB_CourseWork.Controls;
using System;
using System.Collections.Generic;

namespace DB_CourseWork.Models
{
    internal class Order
    {
        private int           _id;
        private DateTime      _orderCreatedTime;
        private DateTime      _orderBookingTime;
        private DateTime      _orderCancelledTime;
        private int           _orderedCarId;
        private int           _orderedHours;
        private int           _orderPaymentId;
        private List<int>     _orderExtendPaymentsIds;
        private bool          _isCancelled;

        public Order()
        {
            _id = -1;
            _orderCreatedTime = DateTime.Now;
            _orderBookingTime = DateTime.MaxValue;
            _orderCancelledTime = DateTime.MaxValue;
            _orderedHours = 0;
            _orderedCarId = -1;
            _orderPaymentId = -1;
            _orderExtendPaymentsIds = new List<int>();
            _isCancelled = false;
        }

        public Order(Payment payment, Car orderedCar, Client user, DateTime orderBookingTime, int orderedHours)
        {
            _id = -1;
            _orderCreatedTime = DateTime.Now;
            _orderBookingTime = orderBookingTime;
            _orderCancelledTime = DateTime.MaxValue;
            _orderedCarId = orderedCar.Id;
            _orderedHours = orderedHours;
            DatabaseContext.DbContext.Payments.Add(payment);
            _orderExtendPaymentsIds = new List<int>();
            _isCancelled = false;
        }

        public Order(Car orderedCar, Client user, DateTime orderBookingTime, int orderedHours)
        {
            _id = -1;
            _orderCreatedTime = DateTime.Now;
            _orderBookingTime = orderBookingTime;
            _orderCancelledTime = DateTime.MaxValue;
            _orderedCarId = orderedCar.Id;
            _orderedHours = orderedHours;

            var _orderPayment = new Payment(user, orderedHours * orderedCar.PricePerHour);
            DatabaseContext.DbContext.Payments.Add(_orderPayment);

            _orderExtendPaymentsIds = new List<int>();
            _isCancelled = false;
        }

        public Order(Car orderedCar, DateTime orderCreatedTime, DateTime orderBookingTime, 
                     DateTime orderCancelledTime, Payment orderPayment, int orderedHours, List<Payment> orderExtendPayments, bool isCancelled)
        {
            _id = -1;
            _orderCreatedTime = orderCreatedTime;
            _orderBookingTime = orderBookingTime;
            _orderCancelledTime = orderCancelledTime;
            _orderedCarId = orderedCar.Id;
            _orderedCarId = orderPayment.Id;
            _orderedHours = orderedHours;
            _orderExtendPaymentsIds = new List<int>();
            foreach (var payment in orderExtendPayments) _orderExtendPaymentsIds.Add(payment.Id);
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

        public int OrderedCarId
        {
            get
            {
                return _orderedCarId;
            }
            set
            {
                _orderedCarId = value;
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

        public int OrderPaymentId
        {
            get
            {
                return _orderPaymentId;
            }
            set
            {
                _orderPaymentId = value;
            }
        }

        public List<int> OrderExtendPaymentsIds
        {
            get
            {
                return _orderExtendPaymentsIds;
            }
            set
            {
                _orderExtendPaymentsIds = value;
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

            var orderPayment = DatabaseContext.DbContext.Payments.Get(_orderPaymentId);
            if (orderPayment.IsPayed)
            {
                orderPayment.Refund();
                DatabaseContext.DbContext.Payments.Update(orderPayment);
            }

            foreach (var paymentId in _orderExtendPaymentsIds)
            {
                var payment = DatabaseContext.DbContext.Payments.Get(paymentId);
                if (payment.IsPayed)
                {
                    payment.Refund();
                    DatabaseContext.DbContext.Payments.Update(payment);
                }
            }

            _orderCancelledTime = DateTime.Now;
            _isCancelled = true;

            return true;
        }

        public bool ExtendOrder(int hours)
        {
            if (hours <= 0 || hours > 192) return false;
            if (_orderedHours + hours > 192) return false;

            var orderPayment = DatabaseContext.DbContext.Payments.Get(_orderPaymentId);
            var orderPaymentUser = DatabaseContext.DbContext.Clients.Get(orderPayment.UserId);
            var orderedCar = DatabaseContext.DbContext.Cars.Get(_orderedCarId);

            var payment = new Payment(orderPaymentUser, hours * orderedCar.PricePerHour);
            var result = payment.Pay();
            if (!result) return false;

            DatabaseContext.DbContext.Payments.Add(payment);

            _orderExtendPaymentsIds.Add(payment.Id);
            _orderedHours += hours;

            return true;
        }
    }
}
