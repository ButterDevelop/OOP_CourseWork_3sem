using DB_CourseWork.Controls;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DB_CourseWork.Models
{
    public class Order
    {
        private int           _id;
        private DateTime      _orderCreatedTime;
        private DateTime      _orderBookingTime;
        private DateTime      _orderCancelledTime;
        private int           _orderedCarId;
        private int           _orderedHours;
        private int           _orderPaymentId;
        private string        _orderExtendPaymentsIdsString;
        private bool          _isCancelled;

        public Order()
        {
            _id = 0;
            _orderCreatedTime = DateTime.UtcNow;
            _orderBookingTime = DateTime.MaxValue;
            _orderCancelledTime = DateTime.MaxValue;
            _orderedHours = 0;
            _orderedCarId = 0;
            _orderPaymentId = 0;
            _orderExtendPaymentsIdsString = string.Empty;
            _isCancelled = false;
        }

        public Order(Payment payment, Car orderedCar, Client user, DateTime orderBookingTime, int orderedHours)
        {
            _id = 0;
            _orderCreatedTime = DateTime.UtcNow;
            _orderBookingTime = orderBookingTime;
            _orderCancelledTime = DateTime.MaxValue;
            _orderedCarId = orderedCar.Id;
            _orderedHours = orderedHours;
            DatabaseContext.DbContext.Payments.Add(payment);
            _orderExtendPaymentsIdsString = string.Empty;
            _isCancelled = false;
        }

        public Order(Car orderedCar, Client user, DateTime orderBookingTime, int orderedHours)
        {
            _id = 0;
            _orderCreatedTime = DateTime.UtcNow;
            _orderBookingTime = orderBookingTime;
            _orderCancelledTime = DateTime.MaxValue;
            _orderedCarId = orderedCar.Id;
            _orderedHours = orderedHours;

            var _orderPayment = new Payment(user, orderedHours * orderedCar.PricePerHour);
            DatabaseContext.DbContext.Payments.Add(_orderPayment);

            _orderExtendPaymentsIdsString = string.Empty;
            _isCancelled = false;
        }

        public Order(Car orderedCar, DateTime orderCreatedTime, DateTime orderBookingTime, 
                     DateTime orderCancelledTime, Payment orderPayment, int orderedHours, List<Payment> orderExtendPayments, bool isCancelled)
        {
            _id = 0;
            _orderCreatedTime = orderCreatedTime;
            _orderBookingTime = orderBookingTime;
            _orderCancelledTime = orderCancelledTime;
            _orderedCarId = orderedCar.Id;
            _orderedCarId = orderPayment.Id;
            _orderedHours = orderedHours;
            foreach (var payment in orderExtendPayments)
            {
                _orderExtendPaymentsIdsString += payment.Id.ToString() + "_";
            }
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

        public string OrderExtendPaymentsIdsString
        {
            get
            {
                return _orderExtendPaymentsIdsString;
            }
            set
            {
                _orderExtendPaymentsIdsString = value;
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

            var orderExtendPaymentsIds = GetOrderExtendPaymentsIdsFromString(_orderExtendPaymentsIdsString);
            foreach (var paymentId in orderExtendPaymentsIds)
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

            _orderExtendPaymentsIdsString += payment.Id.ToString() + "_";
            _orderedHours += hours;

            return true;
        }


        public static string GetStringFromOrderExtendPaymentsIds(List<int> ids)
        {
            string result = "";
            foreach (var id in ids)
            {
                result += id.ToString() + "_";
            }

            return result;
        }

        public static List<int> GetOrderExtendPaymentsIdsFromString(string orderExtendPaymentsIdsString)
        {
            var splittedIds = orderExtendPaymentsIdsString.Split(new char[1] { '_' }, StringSplitOptions.RemoveEmptyEntries).Select(s => int.Parse(s)).ToList();
            return splittedIds;
        }
    }
}
