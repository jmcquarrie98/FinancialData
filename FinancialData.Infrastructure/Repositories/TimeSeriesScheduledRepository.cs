using FinancialData.Domain.Entities;
using FinancialData.Application.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FinancialData.Infrastructure.Repositories;

public class TimeSeriesScheduledRepository : ITimeSeriesScheduledRepository
{
    private readonly FinancialDataContext _context;

    public TimeSeriesScheduledRepository(FinancialDataContext context)
    {
        _context = context;
    }

    public async Task<Stock> GetStockBySymbolAsync(string symbol)
    {
        // Fetch the Stock entity from the database (or create a new one)
        var stock = await _context.Stocks.Include(s => s.MetaData)
            .FirstOrDefaultAsync(s => s.MetaData.Symbol == symbol);

        return stock;
    }

    public async Task CreateStockAsync(Stock stock)
    {
        // Add the Stock entity to the database
        await _context.Stocks.AddAsync(stock);
        await _context.SaveChangesAsync();
    }

    public async Task AddTimeSeriesToStockAsync(Stock stock, IEnumerable<TimeSeries> timeSeries)
    {
        // Add the TimeSeries entity to the Stock's collection
        ((List<TimeSeries>)stock.TimeSeries).AddRange(timeSeries);

        await _context.SaveChangesAsync();
    }
}
