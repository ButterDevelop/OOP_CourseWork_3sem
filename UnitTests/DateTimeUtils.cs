namespace UnitTests
{
    public class DateTimeUtils
    {
        public static double AbsTotalMilliseconds(DateTime time1, DateTime time2)
        {
            return Math.Abs((time1 - time2).TotalMilliseconds);
        }
    }
}
