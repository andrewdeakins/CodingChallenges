namespace PowerTradesReport.Tests
{
    [TestClass]
    public class ReportDateTimeCalculatorTests
    {
        [TestMethod]
        public void GetReportStartDate_Should_Return_2300_On_The_Previous_Day()
        {
            var dateTime = new DateTime(2022,9,1,15,23,45);
            var expectedDateTime = new DateTime(2022,8,31,23,0,0);

            Assert.AreEqual(expectedDateTime, ReportDateTimeCalculator.GetReportStartDate(dateTime));
        }
    }
}
