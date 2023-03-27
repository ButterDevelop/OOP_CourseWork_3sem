using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_CourseWork.Models
{
    internal class CarBrand
    {
        private int    _id;
        private string _name;
        private string _description;

        public CarBrand()
        {
            _id = 0;
            _name = _description = string.Empty;
        }

        public CarBrand(int id, string name, string description)
        {
            _id = id;
            _name = name;
            _description = description;
        }

        public int Id
        {
            get 
            { 
                return _id; 
            }
        }

        public string Name
        {
            get 
            { 
                return _name; 
            }
        }

        public string Description
        {
            get
            {
                return _description;
            }
        }
    }
}
