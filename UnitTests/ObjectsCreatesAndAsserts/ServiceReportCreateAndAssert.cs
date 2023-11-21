using DB_CourseWork.Models;

namespace UnitTests.ObjectsCreatesAndAsserts
{
    public class ServiceReportCreateAndAssert
    {
        public static ServiceReport CreateNewServiceReportForTest()
        {
            return new ServiceReport
            {
                Id = 1,
                AdditionalCost = 100.0,
                EmployeeReport = "Initial Report",
                Description = "Test Service Report",
                FinishedDate = DateTime.MaxValue,
                IsFinished = false,
                IsStarted = true,
                PlannedCompletionDays = 5,
                ServicedCarId = 1,
                StartedDate = DateTime.UtcNow,
                WorkerId = 1
            };
        }

        public static void DefaultServiceReportAssert(ServiceReport serviceReport, string description = "Test Service Report", int id = 1)
        {
            var utcNow = DateTime.UtcNow;
            Assert.IsNotNull(serviceReport);
            Assert.That(serviceReport.Id,                                                                  Is.EqualTo(id));
            Assert.That(serviceReport.AdditionalCost,                                                      Is.EqualTo(100.0));
            Assert.That(serviceReport.EmployeeReport,                                                      Is.EqualTo("Initial Report"));
            Assert.That(serviceReport.Description,                                                         Is.EqualTo(description));
            Assert.That(serviceReport.PlannedCompletionDays,                                               Is.EqualTo(5));
            Assert.That(serviceReport.ServicedCarId,                                                       Is.EqualTo(1));
            Assert.That(DateTimeUtils.AbsTotalMilliseconds(serviceReport.StartedDate, utcNow),             Is.LessThanOrEqualTo(3000));
            Assert.That(DateTimeUtils.AbsTotalMilliseconds(serviceReport.FinishedDate, DateTime.MaxValue), Is.LessThanOrEqualTo(3000));
            Assert.That(serviceReport.WorkerId,                                                            Is.EqualTo(1));
            Assert.IsFalse(serviceReport.IsFinished);
            Assert.IsTrue(serviceReport.IsStarted);
        }
    }
}
