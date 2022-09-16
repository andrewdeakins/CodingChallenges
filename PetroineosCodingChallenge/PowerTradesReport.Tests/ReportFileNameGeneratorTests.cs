namespace PowerTradesReport.Tests
{
    [TestClass]
    public class ReportFileNameGeneratorTests
    {
        [TestMethod]
        public void GenerateFileName_Returns_Expected_FileName()
        {
            var fileName = ReportFileNameGenerator.GenerateFileName(@"C:\temp", new DateTime(2022, 2, 1, 9, 4, 8));
            Assert.AreEqual(@"C:\temp\PowerPosition_20220201_0904.csv", fileName);
        }
    }
}
