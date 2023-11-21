using System.Collections.Generic;

namespace OOP_CourseWork.Models
{
    public class JSON_export
    {
        public class Root
        {
            public List<UserOld> Users { get; set; }
            public List<CarOld> Cars { get; set; }
            public List<OrderOld> Orders { get; set; }
            public List<PaymentOld> Payments { get; set; }
            public List<BankTransactionOld> BankTransactions { get; set; }
            public List<ServiceReportOld> ServiceReports { get; set; }
        }
    }
}
