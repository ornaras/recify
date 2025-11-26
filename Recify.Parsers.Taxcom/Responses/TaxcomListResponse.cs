using Recify.Parsers.Taxcom.Models;

namespace Recify.Parsers.Taxcom.Responses;

public struct TaxcomListResponse<T>
{
	[JsonPropertyName("reportDate")]
	public DateTime Date {get; set;}
	
	[JsonPropertyName("counts")]
	public TaxcomCounts Counts {get; set;}
	
	[JsonPropertyName("records")]
	public IEnumerable<T> Items {get; set;}
}