namespace FinancialData.Application.Services;

public interface ITimeSeriesScheduledService
{
    Task CreateStock(string symbol, string interval, string outputSize);
    Task GetTimeSeries(string symbol, string interval, string outputSize);
}
