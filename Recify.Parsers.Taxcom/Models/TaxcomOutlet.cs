namespace Recify.Parsers.Taxcom.Models;

public struct TaxcomOutlet
{
	[JsonPropertyName("id")]
	public string Id {get; set;}
	
	[JsonPropertyName("name")]
	public string Name {get; set;}
	
	[JsonPropertyName("code")]
	public string Code {get; set;}
	
	[JsonPropertyName("address")]
	public string Address {get; set;}
}