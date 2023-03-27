using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_CourseWork.Models
{
    internal class Admin : User
    {
        public Admin() : base() 
        {
            
        }

        public Admin(int id, string username, string password, string fullname, string email, string phone)
            : base(id, username, password, fullname, email, phone, RolesContainer.Admin)
        {

        }

        public Admin(int id, string username, string salt, string hashedPassword, string fullname, string email, string phone, bool accountDeactivated) 
            : base(id, username, salt, hashedPassword, fullname, email, phone, RolesContainer.Admin, accountDeactivated)
        {

        }

        public void GetFinancialReport(DateTime date1, DateTime date2)
        {
            //
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
