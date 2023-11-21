using DB_CourseWork.Controls;
using System;
using System.Linq;

namespace DB_CourseWork.Models
{
    public class Admin : User
    {
        private int _totalCarsServiced;

        public Admin() : base()
        {
            _totalCarsServiced = 0;
            base.CompleteAccountSetup();
        }

        public Admin(User user) : base(user.UserName, user.Salt, user.HashedPassword, user.FullName, user.Email,
                                       user.Phone, RolesContainer.Employee, user.IsAccountSetupCompleted, user.AccountDeactivated)
        {
            _totalCarsServiced = 0;
            base.CompleteAccountSetup();
        }

        public Admin(string username, string password, string fullname, string email, string phone)
            : base(username, password, fullname, email, phone, RolesContainer.Admin)
        {
            _totalCarsServiced = 0;
            base.CompleteAccountSetup();
        }

        public Admin(string username, string salt, string hashedPassword, string fullname, string email, string phone, bool isAccountSetupCompleted, bool accountDeactivated,
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

        public double GetPotentionalFinancialReport(DateTime date1, DateTime date2)
        {
            var serviceTransactions = DatabaseContext.DbContext.ServiceReports.GetAll().Where(x => x.StartedDate >= date1 &&
                                                                                x.FinishedDate == new DateTime(1900, 1, 1, 0, 0, 0, DateTimeKind.Utc) && 
                                                                                x.StartedDate.AddDays(x.PlannedCompletionDays) <= date2);

            return GetFinancialReport(date1, date2) - serviceTransactions.Sum(x => x.Cost);
        }

        public double GetFinancialReport(DateTime date1, DateTime date2)
        {
            var plusTransactions = DatabaseContext.DbContext.BankTransactions.GetAll().Where(x => x.IsFinished && 
                                                                          x.ToCardNumberOrBankAccountNumber == BankTransaction.OurOrganizationBankAccountNumber && 
                                                                          x.CreatedTime >= date1 &&
                                                                          x.CreatedTime <= date2);
            var minusTransactions = DatabaseContext.DbContext.BankTransactions.GetAll().Where(x => x.IsFinished &&
                                                                           x.FromCardNumberOrBankAccountNumber == BankTransaction.OurOrganizationBankAccountNumber &&
                                                                           x.CreatedTime >= date1 &&
                                                                           x.CreatedTime <= date2);

            return plusTransactions.Sum(x => x.TotalAmount) - minusTransactions.Sum(x => x.TotalAmount);
        }

        public bool PutCarOnService(Car car, string description)
        {
            ServiceReport serviceReport = new ServiceReport(description, car);
            DatabaseContext.DbContext.ServiceReports.Add(serviceReport);

            ++_totalCarsServiced;

            return true;
        }
    }
}
