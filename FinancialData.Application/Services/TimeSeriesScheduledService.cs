using FinancialData.Domain.Entities;
using FinancialData.Application.Repositories;
using FinancialData.Application.Extensions;
using FinancialData.Application.Clients;

namespace FinancialData.Application.Services;

public class TimeSeriesScheduledService : ITimeSeriesScheduledService
{
    private ITimeSeriesClient _timeSeriesClient;
    private ITimeSeriesScheduledRepository _timeSeriesRepository;

    public TimeSeriesScheduledService(ITimeSeriesClient timeSeriesClient, ITimeSeriesScheduledRepository timeSeriesRepository)
    {
        _timeSeriesClient = timeSeriesClient;
        _timeSeriesRepository = timeSeriesRepository;
    }

    public async Task CreateStock(string symbol, string interval, string outputSize)
    {
        var response = await _timeSeriesClient.GetStock(symbol, interval, outputSize);

        var stock = new Stock
        {
            MetaData = response.MetaData.ToEntity(),
            TimeSeries = response.TimeSeries.Select(ts => ts.ToEntity()).ToList()
        };

        await _timeSeriesRepository.CreateStockAsync(stock);
    }

    public async Task GetTimeSeries(string symbol, string interval, string outputSize)
    {
        var response = await _timeSeriesClient.GetTimeSeries(symbol, interval, outputSize);

        var stock = await _timeSeriesRepository.GetStockBySymbolAsync(symbol);

        await _timeSeriesRepository.AddTimeSeriesToStockAsync(stock, response.Select(ts => ts.ToEntity()));
    }
}
