using System.Text.Json.Serialization;

namespace FinancialData.Application.DTOs;

public class TimeSeriesDTO
{
    [JsonPropertyName("datetime")]
    public required string DateTime { get; set; }
    [JsonPropertyName("high")]
    public required string High { get; set; }
    [JsonPropertyName("low")]
    public required string Low { get; set; }
    [JsonPropertyName("open")]
    public required string Open { get; set; }
    [JsonPropertyName("close")]
    public required string Close { get; set; }
    [JsonPropertyName("volume")]
    public required string Volume { get; set; }
}
