using DB_CourseWork.Models;

namespace UnitTests.ObjectsCreatesAndAsserts
{
    public class EmployeeCreateAndAssert
    {
        public static Employee CreateNewEmployeeForTest()
        {
            return new Employee
            {
                Id = 1,
                UserName = "UserName",
                Email = "email@email.com",
                AccountDeactivated = false,
                FullName = "Test Employee",
                HashedPassword = "myHashedPassword",
                IsAccountSetupCompleted = true,
                Phone = "+375001234567",
                Role = RolesContainer.Employee,
                Salt = "MyPasswordSalt",
                BankAccountNumber = "1234567890",
                DateFired = DateTime.MaxValue,
                DateHired = DateTime.UtcNow,
                DateLastSalaryPayed = DateTime.UtcNow,
                DaysWorked = 10,
                IsWorkingNow = true,
                OrderProccessed = 5,
                TotalSalaryPayed = 10000.0
            };
        }

        public static void DefaultEmployeeAssert(Employee employee, string fullName = "Test Employee", int id = 1)
        {
            var utcNow = DateTime.UtcNow;
            Assert.IsNotNull(employee);
            Assert.That(employee.Id,                Is.EqualTo(id));
            Assert.That(employee.UserName,          Is.EqualTo("UserName"));
            Assert.That(employee.Email,             Is.EqualTo("email@email.com"));
            Assert.That(employee.FullName,          Is.EqualTo(fullName));
            Assert.That(employee.HashedPassword,    Is.EqualTo("myHashedPassword"));
            Assert.That(employee.Phone,             Is.EqualTo("+375001234567"));
            Assert.That(employee.Role,              Is.EqualTo(RolesContainer.Employee));
            Assert.That(employee.Salt,              Is.EqualTo("MyPasswordSalt"));
            Assert.That(employee.BankAccountNumber, Is.EqualTo("1234567890"));
            Assert.That(DateTimeUtils.AbsTotalMilliseconds(employee.DateFired, DateTime.MaxValue), Is.LessThanOrEqualTo(3000));
            Assert.That(DateTimeUtils.AbsTotalMilliseconds(employee.DateHired, utcNow),            Is.LessThanOrEqualTo(3000));
            Assert.That(DateTimeUtils.AbsTotalMilliseconds(employee.DateLastSalaryPayed, utcNow),  Is.LessThanOrEqualTo(3000));
            Assert.That(employee.DaysWorked,        Is.EqualTo(10));
            Assert.That(employee.OrderProccessed,   Is.EqualTo(5));
            Assert.That(employee.TotalSalaryPayed,  Is.EqualTo(10000.0));
            Assert.IsTrue(employee.IsWorkingNow);
            Assert.IsFalse(employee.AccountDeactivated);
            Assert.IsTrue(employee.IsAccountSetupCompleted);
        }
    }
}
