using FinancialData.Domain.Enums;
using Quartz;
using FinancialData.Application.Services;

namespace FinancialData.Worker.TimeSeries;

public class GetStock : IJob
{
    private readonly ILogger<GetStock> _logger;
    private readonly ITimeSeriesScheduledService _timeSeriesService;

    public GetStock(ILogger<GetStock> logger,
        ITimeSeriesScheduledService timeSeriesService)
    {
        _logger = logger;
        _timeSeriesService = timeSeriesService;
    }

    public async Task Execute(IJobExecutionContext context)
    {
        var dataMap = context.MergedJobDataMap;

        var symbol = dataMap.GetString("symbol");
        var interval = Interval.FromName(dataMap
            .GetString("interval"));
        var outputSize = dataMap.GetInt("outputSize");

        await _timeSeriesService.CreateStockAsync(symbol, interval, outputSize);
        _logger.LogInformation("{0} stock with interval: {1} has been created", symbol, interval);
    }
}
