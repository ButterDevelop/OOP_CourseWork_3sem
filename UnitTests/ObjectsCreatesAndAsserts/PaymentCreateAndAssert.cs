using DB_CourseWork.Models;

namespace UnitTests.ObjectsCreatesAndAsserts
{
    public class PaymentCreateAndAssert
    {
        public static Payment CreateNewPaymentForTest()
        {
            return new Payment
            {
                Id = 1,
                Cost = 100.0,
                CreatedTime = DateTime.UtcNow,
                IsPayed = false,
                IsRefunded = false,
                PayedTime = DateTime.MaxValue,
                UserId = 1
            };
        }

        public static void DefaultPaymentAssert(Payment payment, double expectedCost = 100.0, int id = 1)
        {
            var utcNow = DateTime.UtcNow;
            Assert.IsNotNull(payment);
            Assert.That(payment.Id,                                                               Is.EqualTo(id));
            Assert.That(payment.Cost,                                                             Is.EqualTo(expectedCost));
            Assert.That(DateTimeUtils.AbsTotalMilliseconds(payment.CreatedTime, utcNow),          Is.LessThanOrEqualTo(3000));
            Assert.That(DateTimeUtils.AbsTotalMilliseconds(payment.PayedTime, DateTime.MaxValue), Is.LessThanOrEqualTo(3000));
            Assert.That(payment.UserId,                                                           Is.EqualTo(1));
            Assert.IsFalse(payment.IsPayed);
            Assert.IsFalse(payment.IsRefunded);
        }
    }
}
