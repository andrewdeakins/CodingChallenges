namespace PowerTradesReport
{
    public class ReportDateTimeCalculator
    {
        public static DateTime GetReportStartDate(DateTime dateTime)
        {
            //Note, this would depend on where the servers are so more robust is to utc
            var dateTimeOffset = dateTime.AddDays(-1);
            return new DateTime(dateTimeOffset.Year, dateTimeOffset.Month, dateTimeOffset.Day, 23, 0, 0);
        }
    }
}
