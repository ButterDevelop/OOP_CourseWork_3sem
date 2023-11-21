using DB_CourseWork.Models;

namespace UnitTests.ObjectsCreatesAndAsserts
{
    public class ClientCreateAndAssert
    {
        public static Client CreateNewClientForTest()
        {
            return new Client
            {
                Id = 1,
                UserName = "UserName",
                Email = "email@email.com",
                AccountDeactivated = false,
                Balance = 100.0,
                CardNumber = "1234567890123456",
                DriverLicense = "DL123456",
                FullName = "Test Client",
                HashedPassword = "myHashedPassword",
                IsAccountSetupCompleted = true,
                OrderCount = 5,
                Passport = "AB1234567",
                Phone = "+375001234567",
                SumRating = 5.0,
                Role = RolesContainer.Client,
                Salt = "MyPasswordSalt"
            };
        }

        public static void DefaultClientAssert(Client client, string fullName = "Test Client", int id = 1)
        {
            Assert.IsNotNull(client);
            Assert.That(client.Id,             Is.EqualTo(id));
            Assert.That(client.UserName,       Is.EqualTo("UserName"));
            Assert.That(client.Email,          Is.EqualTo("email@email.com"));
            Assert.That(client.FullName,       Is.EqualTo(fullName));
            Assert.That(client.HashedPassword, Is.EqualTo("myHashedPassword"));
            Assert.That(client.Phone,          Is.EqualTo("+375001234567"));
            Assert.That(client.Role,           Is.EqualTo(RolesContainer.Client));
            Assert.That(client.Salt,           Is.EqualTo("MyPasswordSalt"));
            Assert.That(client.Balance,        Is.EqualTo(100.0));
            Assert.That(client.CardNumber,     Is.EqualTo("1234567890123456"));
            Assert.That(client.DriverLicense,  Is.EqualTo("DL123456"));
            Assert.That(client.OrderCount,     Is.EqualTo(5));
            Assert.That(client.Passport,       Is.EqualTo("AB1234567"));
            Assert.That(client.SumRating,      Is.EqualTo(5.0));
            Assert.IsFalse(client.AccountDeactivated);
            Assert.IsTrue(client.IsAccountSetupCompleted);
        }
    }
}
