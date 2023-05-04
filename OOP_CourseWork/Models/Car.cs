using OOP_CourseWork.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_CourseWork.Models
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

        public Car()
        {
            _id = 0;
            _brand = string.Empty;
            _model = _carLicensePlate = string.Empty;
            _productionYear = DateTime.MinValue;
            _buyTime = DateTime.MinValue;
            _lastServiceTime = DateTime.MinValue;
            _pricePerHour = 0;
            _locationX = 0;
            _locationY = 0;
        }

        public Car(int id, string brand, string model, string carLicensePlate, double pricePerHour, 
                   DateTime productionYear, DateTime buyTime, DateTime lastServiceTime, double locationX, double locationY)
        {
            _id = id;
            _brand = brand;
            _model = model;
            _carLicensePlate = carLicensePlate;
            _productionYear = productionYear;
            _buyTime = buyTime;
            _lastServiceTime = lastServiceTime;
            _pricePerHour = pricePerHour;
            _locationX = locationX;
            _locationY = locationY;
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

        public bool IsOnServiceNow
        {
            get
            {
                return SaveLoadControl.ServiceReports.FirstOrDefault(x => !x.IsFinished && x.ServicedCar.Id == _id) != null;
            }
        }

        public bool IsOrderedNow
        {
            get
            {
                if (SaveLoadControl.Orders.FirstOrDefault(x => x.OrderedCar == this) is null) return false;
                return SaveLoadControl.Orders.FirstOrDefault(x => x.OrderedCar == this && !x.IsCancelled && x.OrderBookingTime.AddHours(x.OrderHours) > DateTime.Now) != null;
            }
        }

        public void CheckCarLocation()
        {
            UtilsControl.GetRandomCoords(out _locationX, out _locationY);
        }
    }
}
