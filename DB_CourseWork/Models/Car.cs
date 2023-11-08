using DB_CourseWork.Controls;
using System;
using System.Linq;

namespace DB_CourseWork.Models
{
    internal class Car
    {
        private int      _id;
        private string   _brand;
        private string   _model;
        private string   _carLicensePlate;
        private double   _pricePerHour;
        private DateTime _productionYear;
        private DateTime _buyTime;
        private DateTime _lastServiceTime;
        private double   _locationX;
        private double   _locationY;
        private bool     _isHidden;

        public Car()
        {
            _id = -1;
            _brand = string.Empty;
            _model = _carLicensePlate = string.Empty;
            _productionYear = DateTime.MinValue;
            _buyTime = DateTime.MinValue;
            _lastServiceTime = DateTime.MinValue;
            _pricePerHour = 0;
            _locationX = 0;
            _locationY = 0;
            _isHidden = true;
        }

        public Car(string brand, string model, string carLicensePlate, double pricePerHour, 
                   DateTime productionYear, DateTime buyTime, DateTime lastServiceTime, double locationX, double locationY, bool isHidden)
        {
            _id = -1;
            _brand = brand;
            _model = model;
            _carLicensePlate = carLicensePlate;
            _productionYear = productionYear;
            _buyTime = buyTime;
            _lastServiceTime = lastServiceTime;
            _pricePerHour = pricePerHour;
            _locationX = locationX;
            _locationY = locationY;
            _isHidden = isHidden;
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

        public string Brand
        {
            get
            {
                return _brand;
            }
            set
            {
                _brand = value;
            }
        }

        public string Model
        {
            get
            {
                return _model;
            }
            set
            {
                _model = value;
            }
        }

        public string CarLicensePlate
        {
            get
            {
                return _carLicensePlate;
            }
            set
            {
                _carLicensePlate = value;
            }
        }

        public double PricePerHour
        {
            get
            {
                return _pricePerHour;
            }
            set
            {
                _pricePerHour = value;
            }
        }

        public DateTime ProductionYear
        {
            get
            {
                return _productionYear;
            }
            set
            {
                _productionYear = value;
            }
        }

        public DateTime BuyTime
        {
            get
            {
                return _buyTime;
            }
            set
            {
                _buyTime = value;
            }
        }

        public DateTime LastServiceTime
        {
            get
            {
                return _lastServiceTime;
            }
            set
            {
                _lastServiceTime = value;
            }
        }

        public double LocationX
        {
            get
            {
                return _locationX;
            }
            set
            {
                _locationX = value;
            }
        }

        public double LocationY
        {
            get
            {
                return _locationY;
            }
            set
            {
                _locationY = value;
            }
        }

        public bool IsHidden
        {
            get
            {
                return _isHidden;
            }
            set
            {
                _isHidden = value;
            }
        }

        public bool IsOnServiceNow
        {
            get
            {
                return DatabaseContext.DbContext.ServiceReports.GetAll().FirstOrDefault(x => !x.IsFinished && x.ServicedCarId == _id) != null;
            }
        }

        public bool IsOrderedNow
        {
            get
            {
                if (DatabaseContext.DbContext.Orders.GetAll().FirstOrDefault(x => x.OrderedCarId == Id) is null) return false;
                return DatabaseContext.DbContext.Orders.GetAll().FirstOrDefault(x => x.OrderedCarId == Id && !x.IsCancelled && x.OrderBookingTime.AddHours(x.OrderHours) > DateTime.Now) != null;
            }
        }

        public void HideOrShow()
        {
            _isHidden = !_isHidden;
        }

        public void CheckCarLocation()
        {
            UtilsControl.GetRandomCoords(out _locationX, out _locationY);
        }
    }
}
