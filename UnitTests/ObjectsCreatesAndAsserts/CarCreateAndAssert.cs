using DB_CourseWork.Models;

namespace UnitTests.ObjectsCreatesAndAsserts
{
    public class CarCreateAndAssert
    {
        public static Car CreateNewCarForTest()
        {
            return new Car
            {
                Id = 1,
                Brand = "Test Brand",
                BuyTime = DateTime.UtcNow,
                CarLicensePlate = "TEST1234",
                IsHidden = false,
                LastServiceTime = DateTime.UtcNow,
                LocationX = 0.0,
                LocationY = 0.0,
                Model = "Test Model",
                PricePerHour = 10.0,
                ProductionYear = new DateTime(2010, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            };
        }

        public static void DefaultCarAssert(Car car, string brand = "Test Brand", int id = 1)
        {
            var utcNow = DateTime.UtcNow;
            Assert.IsNotNull(car);
            Assert.That(car.Id,              Is.EqualTo(id));
            Assert.That(car.Brand,           Is.EqualTo(brand));
            Assert.That(car.CarLicensePlate, Is.EqualTo("TEST1234"));
            Assert.IsFalse(car.IsHidden);
            Assert.That(car.Model,           Is.EqualTo("Test Model"));
            Assert.That(car.PricePerHour,    Is.EqualTo(10.0));

            Assert.That(car.ProductionYear,  Is.EqualTo(new DateTime(2010, 1, 1, 0, 0, 0, DateTimeKind.Utc)));
            Assert.That(DateTimeUtils.AbsTotalMilliseconds(car.BuyTime, utcNow),         Is.LessThanOrEqualTo(3000));
            Assert.That(DateTimeUtils.AbsTotalMilliseconds(car.LastServiceTime, utcNow), Is.LessThanOrEqualTo(3000));

            Assert.That(car.LocationX,       Is.EqualTo(0.0));
            Assert.That(car.LocationY,       Is.EqualTo(0.0));
        }
    }
}
