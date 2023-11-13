using FinancialData.Application.Common;
using FinancialData.Application.DTOs;
using System.Net.Http.Json;

namespace FinancialData.Application.Clients;

public class TimeSeriesClient : ITimeSeriesClient
{
    private HttpClient _httpClient;

    public TimeSeriesClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<StockDTO> GetStock(string symbol, string interval, string outputSize)
    {
        var endpoint = TimeSeriesEndpointBuilder.BuildTimeSeriesEndpoint(symbol, interval, outputSize);
        var response = await _httpClient.GetFromJsonAsync<StockDTO>(endpoint);

        return response;
    }

    public async Task<IEnumerable<TimeSeriesDTO>> GetTimeSeries(string symbol, string interval, string outputSize)
    {
        var endpoint = TimeSeriesEndpointBuilder.BuildTimeSeriesEndpoint(symbol, interval, outputSize);
        var response = await _httpClient.GetFromJsonAsync<IEnumerable<TimeSeriesDTO>>(endpoint);

        return response;
    }
}
