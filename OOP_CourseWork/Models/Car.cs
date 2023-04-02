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
        private CarBrand _brand;
        private string   _model;
        private double   _pricePerHour;
        private DateTime _productionYear;
        private DateTime _buyTime;
        private DateTime _lastServiceTime;

        public Car()
        {
            _id = 0;
            _brand = new CarBrand();
            _model = string.Empty;
            _productionYear = DateTime.MinValue;
            _buyTime = DateTime.MinValue;
            _lastServiceTime = DateTime.MinValue;
            _pricePerHour = 0;
        }

        public Car(int id, CarBrand brand, string model, double pricePerHour, 
                   DateTime productionYear, DateTime buyTime, DateTime lastServiceTime)
        {
            _id = id;
            _brand = brand;
            _model = model;
            _productionYear = productionYear;
            _buyTime = buyTime;
            _lastServiceTime = lastServiceTime;
            _pricePerHour = pricePerHour;
        }

        public int Id 
        { 
            get 
            { 
                return _id; 
            } 
        }

        public CarBrand Brand
        {
            get
            {
                return _brand;
            }
        }

        public string Model
        {
            get
            {
                return _model;
            }
        }

        public double PricePerHour
        {
            get
            {
                return _pricePerHour;
            }
        }

        public DateTime ProductionYear
        {
            get
            {
                return _productionYear;
            }
        }

        public DateTime BuyTime
        {
            get
            {
                return _buyTime;
            }
        }

        public DateTime LastServiceTime
        {
            get
            {
                return _lastServiceTime;
            }
        }

        public bool IsOnServiceNow
        {
            get
            {
                return SaveLoadControl.ServiceReports.FirstOrDefault(x => !x.IsFinished && x.ServicedCar.Id == _id) != null;
            }
        }
    }
}
