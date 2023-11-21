using DB_CourseWork.Models;

namespace UnitTests.ObjectsCreatesAndAsserts
{
    public class OrderCreateAndAssert
    {
        public static Order CreateNewOrderForTest()
        {
            return new Order
            {
                Id = 1,
                IsCancelled = false,
                OrderBookingTime = DateTime.UtcNow,
                OrderCancelledTime = DateTime.MaxValue,
                OrderCreatedTime = DateTime.UtcNow,
                OrderExtendPaymentsIdsString = Order.GetStringFromOrderExtendPaymentsIds(new List<int>() { 1, 2, 3 }),
                OrderedCarId = 1,
                OrderHours = 3,
                OrderPaymentId = 1
            };
        }

        public static void DefaultOrderAssert(Order order, int orderedCarId, int id = 1)
        {
            var utcNow = DateTime.UtcNow;
            Assert.IsNotNull(order);
            Assert.That(order.Id,                                                                        Is.EqualTo(id));
            Assert.That(order.OrderedCarId,                                                              Is.EqualTo(orderedCarId));
            Assert.That(order.OrderHours,                                                                Is.EqualTo(3));
            Assert.That(order.OrderPaymentId,                                                            Is.EqualTo(1));
            Assert.IsFalse(order.IsCancelled);
            Assert.That(DateTimeUtils.AbsTotalMilliseconds(order.OrderBookingTime, utcNow),              Is.LessThanOrEqualTo(3000));
            Assert.That(DateTimeUtils.AbsTotalMilliseconds(order.OrderCreatedTime, utcNow),              Is.LessThanOrEqualTo(3000));
            Assert.That(DateTimeUtils.AbsTotalMilliseconds(order.OrderCancelledTime, DateTime.MaxValue), Is.LessThanOrEqualTo(3000));
            Assert.That(Order.GetStringFromOrderExtendPaymentsIds(new List<int>() { 1, 2, 3 }),          Is.EqualTo(order.OrderExtendPaymentsIdsString));
        }
    }
}
