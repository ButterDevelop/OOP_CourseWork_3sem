using OOP_CourseWork.Controls;
using System;
using System.Linq;

namespace OOP_CourseWork.Models
{
    internal class Admin : User
    {
        private int _totalCarsServiced;

        public Admin() : base()
        {
            _totalCarsServiced = 0;
            base.CompleteAccountSetup();
        }

        public Admin(User user) : base(user.Id, user.UserName, user.Salt, user.HashedPassword, user.FullName, user.Email,
                                       user.Phone, RolesContainer.Employee, user.IsAccountSetupCompleted, user.AccountDeactivated)
        {
            _totalCarsServiced = 0;
            base.CompleteAccountSetup();
        }

        public Admin(int id, string username, string password, string fullname, string email, string phone)
            : base(id, username, password, fullname, email, phone, RolesContainer.Admin)
        {
            _totalCarsServiced = 0;
            base.CompleteAccountSetup();
        }

        public Admin(int id, string username, string salt, string hashedPassword, string fullname, string email, string phone, bool isAccountSetupCompleted, bool accountDeactivated,
                     int totalCarServiced) 
            : base(id, username, salt, hashedPassword, fullname, email, phone, RolesContainer.Admin, isAccountSetupCompleted, accountDeactivated)
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
            var serviceTransactions = SaveLoadControl.ServiceReports.Where(x => x.StartedDate >= date1 &&
                                                                                x.FinishedDate == DateTime.MinValue && 
                                                                                x.StartedDate.AddDays(x.PlannedCompletionDays) <= date2);

            return GetFinancialReport(date1, date2) - serviceTransactions.Sum(x => x.Cost);
        }

        public double GetFinancialReport(DateTime date1, DateTime date2)
        {
            var plusTransactions = SaveLoadControl.BankTransactions.Where(x => x.IsFinished && 
                                                                          x.ToCardNumberOrBankAccountNumber == BankTransaction.OurOrganizationBankAccountNumber && 
                                                                          x.CreatedTime >= date1 &&
                                                                          x.CreatedTime <= date2);
            var minusTransactions = SaveLoadControl.BankTransactions.Where(x => x.IsFinished &&
                                                                           x.FromCardNumberOrBankAccountNumber == BankTransaction.OurOrganizationBankAccountNumber &&
                                                                           x.CreatedTime >= date1 &&
                                                                           x.CreatedTime <= date2);

            return plusTransactions.Sum(x => x.TotalAmount) - minusTransactions.Sum(x => x.TotalAmount);
        }

        public bool PutCarOnService(Car car, string description)
        {
            ServiceReport serviceReport = new ServiceReport(SaveLoadControl.ServiceReports.Count, description, car);
            SaveLoadControl.ServiceReports.Add(serviceReport);

            ++_totalCarsServiced;

            return true;
        }
    }
}
