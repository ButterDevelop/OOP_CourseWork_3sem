using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_CourseWork.Models
{
    internal class Employee : User
    {
        private int      _ordersProccessed;
        private int      _hoursWorked;
        private DateTime _dateHired;
        private DateTime _dateFired;
        private double   _salaryPerHour;
        private bool     _isWorkingNow;

        public Employee() : base() 
        {
            _ordersProccessed = _hoursWorked = 0;
            _dateHired = DateTime.Now;
            _dateFired = DateTime.Now;
            _salaryPerHour = 0;
            _isWorkingNow = true;
        }

        public Employee(int id, string username, string password, string fullname, string email, string phone)
            : base(id, username, password, fullname, email, phone, RolesContainer.Employee)
        {
            _ordersProccessed = 0;
            _hoursWorked = 0;
            _dateHired = DateTime.Now;
            _dateFired = DateTime.MinValue;
            _salaryPerHour = 0;
            _isWorkingNow = true;
        }

        public Employee(int id, string username, string salt, string hashedPassword, string fullname, string email, string phone, bool accountDeactivated,
                        int ordersProccessed, int hoursWorked, DateTime dateHired, DateTime dateFired, double salaryPerHour, bool isWorkingNow) 
            : base(id, username, salt, hashedPassword, fullname, email, phone, RolesContainer.Employee, accountDeactivated)
        {
            _ordersProccessed = ordersProccessed;
            _hoursWorked = hoursWorked;
            _dateHired = dateHired;
            _dateFired = dateFired;
            _salaryPerHour = salaryPerHour;
            _isWorkingNow = isWorkingNow;
        }

        public int OrderProccessed
        {
            get
            {
                return _ordersProccessed;
            }
        }

        public int HoursWorked
        {
            get
            {
                return _hoursWorked;
            }
        }

        public DateTime DateHired
        {
            get
            {
                return _dateHired;
            }
        }

        public DateTime DateFired
        {
            get
            {
                return _dateFired;
            }
        }

        public bool IsWorkingNow
        {
            get
            {
                return _isWorkingNow;
            }
        }

        public double SalaryPerHour
        {
            get
            {
                return _salaryPerHour;
            }
        }

        public double Salary
        {
            get
            {
                return (_salaryPerHour * _hoursWorked) + _ordersProccessed;
            }
        }

        public override string ToString()
        {
            return base.ToString() + ";" + _ordersProccessed + ";" + _hoursWorked + ";" + _dateHired + ";" + _dateFired + ";" + _isWorkingNow;
        }

        public void FireEmployee()
        {
            if (_isWorkingNow)
            {
                _dateFired = DateTime.Now;
                _isWorkingNow = false;
                base.DeactivateAccount();
            }
        }
    }
}
