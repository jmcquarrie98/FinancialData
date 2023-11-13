using System.Text.Json.Serialization;

namespace FinancialData.Application.DTOs;

public class MetaDataDTO
{
    [JsonPropertyName("symbol")]
    public required string Symbol { get; set; }
    [JsonPropertyName("type")]
    public required string Type { get; set; }
    [JsonPropertyName("currency")]
    public required string Currency { get; set; }
    [JsonPropertyName("exchange")]
    public required string Exchange { get; set; }
    [JsonPropertyName("exchange_timezone")]
    public required string ExchangeTimeZone { get; set; }
    [JsonPropertyName("interval")]
    public required string Interval { get; set; }
}
