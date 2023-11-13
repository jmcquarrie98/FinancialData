namespace FinancialData.Application.Common;

public static class TimeSeriesEndpointBuilder
{
    public static string BuildTimeSeriesEndpoint(string symbol, string interval, string outputSize)
    {
        return $"time_series?symbol={symbol}&interval={interval}&outputsize={outputSize}";
    }
}
