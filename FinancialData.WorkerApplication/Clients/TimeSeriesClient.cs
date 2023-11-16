using FinancialData.Domain.Enums;
using FinancialData.Common.Utilities;
using FinancialData.Common.Dtos;
using System.Text.Json;
using System.Net.Http.Json;

namespace FinancialData.Application.Clients;

public class TimeSeriesClient : ITimeSeriesClient
{
    private HttpClient _httpClient;

    public TimeSeriesClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<StockDto> GetStockAsync(string symbol, Interval interval, int outputSize)
    {
        var endpoint = TimeSeriesEndpointBuilder.BuildTimeSeriesEndpoint(symbol, interval, outputSize);
        var response = await _httpClient.GetFromJsonAsync<StockDto>(endpoint, new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower });

        return response;
    }

    public async Task<IEnumerable<TimeSeriesDto>> GetTimeSeriesAsync(string symbol, Interval interval, int outputSize)
    {
        var endpoint = TimeSeriesEndpointBuilder.BuildTimeSeriesEndpoint(symbol, interval, outputSize);
        var response = await _httpClient.GetFromJsonAsync<StockDto>(endpoint, new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower });

        return response.TimeSeries;
    }
}
