namespace Recify.Parsers.Taxcom.Models;

public struct TaxcomCounts
{
	[JsonPropertyName("recordCount")]
	public int TotalCount {get; set;}
	
	[JsonPropertyName("recordFilteredCount")]
	public int FilteredCount {get; set;}
	
	[JsonPropertyName("recordInResponceCount")]
	public int Count {get; set;}
}