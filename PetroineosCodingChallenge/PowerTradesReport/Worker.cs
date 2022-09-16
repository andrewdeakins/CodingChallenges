using Microsoft.Extensions.Options;
using Services;

namespace PowerTradesReport
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly PowerTradesConfiguration _configuration;
        private readonly IPowerService _powerService;
        public Worker(ILogger<Worker> logger, IOptions<PowerTradesConfiguration> configuration, IPowerService powerService)
        {
            _logger = logger;
            _configuration = configuration.Value;
            _powerService = powerService;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var processor = new ReportProcessor(_logger, _powerService, _configuration);
                Thread th = new(new ThreadStart(processor.ProcessTrades));
                th.Start();

                _logger.LogInformation("Creating Report running at: {time}", DateTimeOffset.Now);
                await Task.Delay(_configuration.intervalInMinutes * 60000, stoppingToken);
            }
        }
    }
}