using DB_CourseWork.Controls;
using System;
using System.Collections.Generic;

namespace OOP_CourseWork.Models
{
    public class OrderOld
    {
        private int _id;
        private DateTime _orderCreatedTime;
        private DateTime _orderBookingTime;
        private DateTime _orderCancelledTime;
        private CarOld _orderedCar;
        private int _orderedHours;
        private PaymentOld _orderPayment;
        private List<PaymentOld> _orderExtendPayments;
        private bool _isCancelled;

        public OrderOld()
        {
            _id = 0;
            _orderCreatedTime = DateTime.UtcNow;
            _orderBookingTime = DateTime.MaxValue;
            _orderCancelledTime = DateTime.MaxValue;
            _orderedHours = 0;
            _orderedCar = new CarOld();
            _orderPayment = new PaymentOld();
            _orderExtendPayments = new List<PaymentOld>();
            _isCancelled = false;
        }

        public OrderOld(int id, PaymentOld payment, CarOld orderedCar, ClientOld user, DateTime orderBookingTime, int orderedHours)
        {
            _id = id;
            _orderCreatedTime = DateTime.UtcNow;
            _orderBookingTime = orderBookingTime;
            _orderCancelledTime = DateTime.MaxValue;
            _orderedCar = orderedCar;
            _orderedHours = orderedHours;
            _orderPayment = payment;
            MigrateOldData.Payments.Add(_orderPayment);
            _orderExtendPayments = new List<PaymentOld>();
            _isCancelled = false;
        }

        public OrderOld(int id, CarOld orderedCar, ClientOld user, DateTime orderBookingTime, int orderedHours)
        {
            _id = id;
            _orderCreatedTime = DateTime.UtcNow;
            _orderBookingTime = orderBookingTime;
            _orderCancelledTime = DateTime.MaxValue;
            _orderedCar = orderedCar;
            _orderedHours = orderedHours;
            _orderPayment = new PaymentOld(MigrateOldData.Payments.Count, user, orderedHours * orderedCar.PricePerHour);
            MigrateOldData.Payments.Add(_orderPayment);
            _orderExtendPayments = new List<PaymentOld>();
            _isCancelled = false;
        }

        public OrderOld(int id, CarOld orderedCar, DateTime orderCreatedTime, DateTime orderBookingTime,
                     DateTime orderCancelledTime, PaymentOld orderPayment, int orderedHours, List<PaymentOld> orderExtendPayments, bool isCancelled)
        {
            _id = id;
            _orderCreatedTime = orderCreatedTime;
            _orderBookingTime = orderBookingTime;
            _orderCancelledTime = orderCancelledTime;
            _orderedCar = orderedCar;
            _orderPayment = orderPayment;
            _orderedHours = orderedHours;
            _orderExtendPayments = orderExtendPayments;
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

        public CarOld OrderedCar
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

        public PaymentOld OrderPayment
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

        public List<PaymentOld> OrderExtendPayments
        {
            get
            {
                return _orderExtendPayments;
            }
            set
            {
                _orderExtendPayments = value;
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
