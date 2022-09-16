using Services;

namespace PowerTradesReport.Tests
{
   
    [TestClass]
    public class TradePositionAggregatorTests
    {
        [TestMethod]
        public void Aggregate_Should_Aggregate_Trade_Positions_And_Return_Report_OutputLines()
        {
            var allTrades = new List<PowerPeriod>();

            for (var i = 1; i <= 24; i++)
            { 
                allTrades.Add(new PowerPeriod { Period = i, Volume = i });
            }

            for (var i = 1; i <= 24; i++)
            {
                allTrades.Add(new PowerPeriod { Period = i, Volume = 10 });
            }

            var result = TradePositionAggregator.Aggregate(allTrades);
            Assert.AreEqual(24, result.Count());

            for (var i = 0; i < 24; i++)
            {
                var expected = (i + 1) + 10;
                Assert.AreEqual(expected, result.ElementAt(i).Volume);
            }
        }
    }
}
