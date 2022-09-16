using Polly;
using Services;

namespace PowerTradesReport
{
    public class ReportProcessor
    {
        IPowerService _powerService;
        ILogger _logger;
        PowerTradesConfiguration _configuration;
        public ReportProcessor(ILogger logger, IPowerService powerService, PowerTradesConfiguration configuration)
        {
            _logger = logger;
            _powerService = powerService;
            _configuration = configuration;
        }
        public void ProcessTrades()
        {
            var executionTime = ReportDateTimeCalculator.GetReportStartDate(DateTime.Now);
            var reportFileName = ReportFileNameGenerator.GenerateFileName(_configuration.csvLocation, executionTime);

            _logger.LogInformation($"Process extract to file {reportFileName} for date {executionTime:D}");

            var pause = TimeSpan.FromSeconds(60);

            var executionPolicy = Policy.Handle<PowerServiceException>().WaitAndRetryForever(p => pause, 
                onRetry: (exception, attemptNumber) => {
                    _logger.LogError($"Get Trades Failed with exception {exception.Message} retrying");
                }
            );

            executionPolicy.Execute(() => {
                var trades = _powerService.GetTrades(executionTime);
                var reportLineItems = TradePositionAggregator.Aggregate(trades.SelectMany(t => t.Periods));

                var reportLines = reportLineItems.Select(r => r.ToString()).ToList();
                File.WriteAllLines(reportFileName, reportLines.ToArray());
                _logger.LogInformation($"Written Log File {reportFileName}");
            });
        }
    }
}
