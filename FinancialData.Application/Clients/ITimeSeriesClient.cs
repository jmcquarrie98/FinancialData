using FinancialData.Application.DTOs;

namespace FinancialData.Application.Clients;

public interface ITimeSeriesClient
{
    public Task<StockDTO> GetStock(string symbol, string interval, string outputSize);
    public Task<IEnumerable<TimeSeriesDTO>> GetTimeSeries(string symbol, string interval, string outputSize);
}
