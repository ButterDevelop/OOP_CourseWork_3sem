using DB_CourseWork.Models;

namespace OOP_CourseWork.Models
{
    public class AdminOld : UserOld
    {
        private int _totalCarsServiced;

        public AdminOld() : base()
        {
            _totalCarsServiced = 0;
            base.CompleteAccountSetup();
        }

        public AdminOld(UserOld user) : base(user.UserName, user.Salt, user.HashedPassword, user.FullName, user.Email,
                                       user.Phone, RolesContainer.Employee, user.IsAccountSetupCompleted, user.AccountDeactivated)
        {
            _totalCarsServiced = 0;
            base.CompleteAccountSetup();
        }

        public AdminOld(string username, string password, string fullname, string email, string phone)
            : base(username, password, fullname, email, phone, RolesContainer.Admin)
        {
            _totalCarsServiced = 0;
            base.CompleteAccountSetup();
        }

        public AdminOld(string username, string salt, string hashedPassword, string fullname, string email, string phone, bool isAccountSetupCompleted, bool accountDeactivated,
                     int totalCarServiced) 
            : base(username, salt, hashedPassword, fullname, email, phone, RolesContainer.Admin, isAccountSetupCompleted, accountDeactivated)
        {
            _totalCarsServiced = totalCarServiced;
            base.CompleteAccountSetup();
        }


        public int TotalCarsServiced
        {
            get
            {
                return _totalCarsServiced;
            }
            set
            {
                _totalCarsServiced = value;
            }
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
