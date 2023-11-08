using System.Collections.Generic;

namespace DB_CourseWork.Models
{
    internal class JSON_export
    {
        public class Root
        {
            public List<User> Users { get; set; }
            public List<Car> Cars { get; set; }
            public List<Order> Orders { get; set; }
            public List<Payment> Payments { get; set; }
            public List<BankTransaction> BankTransactions { get; set; }
            public List<ServiceReport> ServiceReports { get; set; }
        }
    }
}
