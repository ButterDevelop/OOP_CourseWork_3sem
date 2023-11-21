using DB_CourseWork.Models;

namespace UnitTests.ObjectsCreatesAndAsserts
{
    public class BankTransactionCreateAndAssert
    {
        public static BankTransaction CreateNewBankTransactionForTest()
        {
            return new BankTransaction
            {
                Id = 1,
                CancelledTime = DateTime.UtcNow,
                CreatedTime = DateTime.UtcNow,
                FromCardNumberOrBankAccountNumber = "1234567890",
                IsCancelled = false,
                IsFinished = true,
                PayedTime = DateTime.UtcNow,
                ToCardNumberOrBankAccountNumber = "0987654321",
                TotalAmount = 1000,
                TotalTries = 1,
                UserId = 1
            };
        }

        public static void DefaultBankTransactionAssert(BankTransaction transaction, double expectedTotalAmount = 1000, int id = 1)
        {
            var utcNow = DateTime.UtcNow;
            Assert.IsNotNull(transaction);
            Assert.That(transaction.Id,                                Is.EqualTo(id));
            Assert.That(transaction.TotalAmount,                       Is.EqualTo(expectedTotalAmount));
            Assert.That(transaction.FromCardNumberOrBankAccountNumber, Is.EqualTo("1234567890"));
            Assert.That(transaction.ToCardNumberOrBankAccountNumber,   Is.EqualTo("0987654321"));
            Assert.That(transaction.TotalTries,                        Is.EqualTo(1));
            Assert.That(transaction.UserId,                            Is.EqualTo(1));
            Assert.That(DateTimeUtils.AbsTotalMilliseconds(transaction.CreatedTime, utcNow),   Is.LessThanOrEqualTo(3000));
            Assert.That(DateTimeUtils.AbsTotalMilliseconds(transaction.CancelledTime, utcNow), Is.LessThanOrEqualTo(3000));
            Assert.That(DateTimeUtils.AbsTotalMilliseconds(transaction.PayedTime, utcNow),     Is.LessThanOrEqualTo(3000));
            Assert.That(transaction.IsCancelled,                       Is.False);
            Assert.That(transaction.IsFinished,                        Is.True);
        }
    }
}
