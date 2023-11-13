using FinancialData.Domain.Entities;
using FinancialData.Application.DTOs;

namespace FinancialData.Application.Extensions;

public static class TimeSeriesToEntityExtensions
{
    public static MetaData ToEntity(this MetaDataDTO metaDataDTO)
    {
        return new MetaData
        {
            Symbol = metaDataDTO.Symbol,
            Type = metaDataDTO.Type,
            Currency = metaDataDTO.Currency,
            Exchange = metaDataDTO.Exchange,
            ExchangeTimeZone = metaDataDTO.ExchangeTimeZone,
            Interval = metaDataDTO.Interval,
        };
    }

    public static TimeSeries ToEntity(this TimeSeriesDTO timeSeriesDTO)
    {
        return new TimeSeries
        {
            DateTime = timeSeriesDTO.DateTime,
            High = timeSeriesDTO.High,
            Low = timeSeriesDTO.Low,
            Open = timeSeriesDTO.Open,
            Close = timeSeriesDTO.Close,
            Volume = timeSeriesDTO.Volume,
        };
    }
}
