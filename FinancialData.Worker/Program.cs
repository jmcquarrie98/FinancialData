using FinancialData.Worker;
using FinancialData.Application.Options;
using FinancialData.Application.Clients;
using FinancialData.Application.Repositories;
using FinancialData.Application.Services;
using FinancialData.Infrastructure;
using FinancialData.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        services.AddHttpClient<ITimeSeriesClient, TimeSeriesClient>(client =>
        {
            var options = hostContext.Configuration.GetSection(nameof(RapidApiOptions))
                .Get<RapidApiOptions>();
            
            client.BaseAddress = new Uri(options.BaseUrl);
            client.DefaultRequestHeaders.Add("X-RapidAPI-Host", options.Host);
            client.DefaultRequestHeaders.Add("X-RapidAPI-Key", options.Key);
        })
        .ConfigurePrimaryHttpMessageHandler(() =>
        {
            return new SocketsHttpHandler()
            {
                PooledConnectionLifetime = TimeSpan.FromMinutes(2)
            };
        })
        .SetHandlerLifetime(Timeout.InfiniteTimeSpan);

        services.AddDbContext<FinancialDataContext>(options =>
            options.UseSqlServer(hostContext.Configuration.GetConnectionString("DefaultConnection")));
        
        services.AddScoped<ITimeSeriesScheduledService, TimeSeriesScheduledService>();
        services.AddScoped<ITimeSeriesScheduledRepository, TimeSeriesScheduledRepository>();

        services.AddHostedService<Worker>();
    })
    .Build();

host.Run();
