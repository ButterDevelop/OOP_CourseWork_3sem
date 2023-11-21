using DB_CourseWork.Models;

namespace UnitTests.ObjectsCreatesAndAsserts
{
    public class AdminCreateAndAssert
    {
        public static Admin CreateNewAdminForTest()
        {
            return new Admin
            {
                // Инициализация полей администратора для тестирования
                Id = 1,
                UserName = "TestUserName",
                Email = "test@email.com",
                FullName = "Test Admin",
                HashedPassword = "hashedPassword",
                Phone = "123456789",
                Role = RolesContainer.Admin,
                Salt = "salt",
                AccountDeactivated = false,
                IsAccountSetupCompleted = true
            };
        }

        public static void DefaultAdminAssert(Admin admin, string fullName = "Test Admin", int id = 1)
        {
            Assert.IsNotNull(admin);
            Assert.That(admin.Id,                      Is.EqualTo(id));
            Assert.That(admin.UserName,                Is.EqualTo("TestUserName"));
            Assert.That(admin.Email,                   Is.EqualTo("test@email.com"));
            Assert.That(admin.FullName,                Is.EqualTo(fullName));
            Assert.That(admin.HashedPassword,          Is.EqualTo("hashedPassword"));
            Assert.That(admin.Phone,                   Is.EqualTo("123456789"));
            Assert.That(admin.Role,                    Is.EqualTo(RolesContainer.Admin));
            Assert.That(admin.Salt,                    Is.EqualTo("salt"));
            Assert.That(admin.AccountDeactivated,      Is.False);
            Assert.That(admin.IsAccountSetupCompleted, Is.True);
        }
    }
}
