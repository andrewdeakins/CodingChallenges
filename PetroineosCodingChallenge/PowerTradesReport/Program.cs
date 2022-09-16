using PowerTradesReport;
using Services;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) => {
        
        IConfiguration config = context.Configuration;
        services.Configure<PowerTradesConfiguration>(config.GetSection("PowerTradesConfiguration"));
        services.AddTransient<IPowerService, PowerService>();
        services.AddHostedService<Worker>();
    })
    .Build();

await host.RunAsync();
