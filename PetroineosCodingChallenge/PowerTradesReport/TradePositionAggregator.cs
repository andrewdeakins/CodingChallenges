using Services;

namespace PowerTradesReport
{
    public class TradePositionAggregator
    {
        public static IEnumerable<ReportLineItem> Aggregate(IEnumerable<PowerPeriod> trades)
        {
            var groupedTradesByPeriod = trades.GroupBy(t => t.Period);
            var result = new List<ReportLineItem>();

            foreach (var groupedTrades in groupedTradesByPeriod)
            {
                var totalVolume = groupedTrades.Sum(t => t.Volume);
                result.Add(new ReportLineItem(groupedTrades.Key, totalVolume));
            }            

            return result;
        }
    }
}
