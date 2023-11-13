using FinancialData.Domain.Entities;

namespace FinancialData.Application.Repositories;

public interface ITimeSeriesScheduledRepository
{
    public Task<Stock> GetStockBySymbolAsync(string symbol);
    public Task CreateStockAsync(Stock stock);
    public Task AddTimeSeriesToStockAsync(Stock stock, IEnumerable<TimeSeries> timeSeries);
}
