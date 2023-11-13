﻿namespace FinancialData.Domain.Entities;

public class MetaData
{
    public int Id { get; set; }
    public required string Symbol { get; set; }
    public required string Type { get; set; }
    public required string Currency {  get; set; }
    public required string Exchange { get; set; }
    public required string ExchangeTimeZone { get; set; }
    public required string Interval { get; set; }
    public Stock? Stock { get; set; } = null!;
}
