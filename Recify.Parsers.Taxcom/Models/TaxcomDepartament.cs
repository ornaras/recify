namespace Recify.Parsers.Taxcom.Models;

public struct TaxcomDepartament
{
	[JsonPropertyName("id")]
	public string Id {get; set;}
	
	[JsonPropertyName("name")]
	public string Name {get; set;}
	
	[JsonPropertyName("code")]
	public string Code {get; set;}
}