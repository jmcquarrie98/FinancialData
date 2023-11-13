using System.Text.Json.Serialization;

namespace FinancialData.Application.DTOs;

public class StockDTO
{
    [JsonPropertyName("meta")]
    public required MetaDataDTO MetaData { get; set; }
    [JsonPropertyName("values")]
    public required ICollection<TimeSeriesDTO> TimeSeries { get; set; }
}
