using FinancialData.Domain.Entities;
using FinancialData.Application.DTOs;

namespace FinancialData.Application.Extensions;

public static class TimeSeriesToDTOExtensions
{
    public static MetaDataDTO ToDTO(this MetaData metaData)
    {
        return new MetaDataDTO
        {
            Symbol = metaData.Symbol,
            Type = metaData.Type,
            Currency = metaData.Currency,
            Exchange = metaData.Exchange,
            ExchangeTimeZone = metaData.ExchangeTimeZone,
            Interval = metaData.Interval
        };
    }

    public static TimeSeriesDTO ToDTO(this TimeSeries timeSeries)
    {
        return new TimeSeriesDTO
        {
            DateTime = timeSeries.DateTime,
            High = timeSeries.High,
            Low = timeSeries.Low,
            Open = timeSeries.Open,
            Close = timeSeries.Close,
            Volume = timeSeries.Volume,
        };
    }
}
