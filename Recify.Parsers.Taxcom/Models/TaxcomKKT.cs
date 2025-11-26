#pragma warning disable S101
namespace Recify.Parsers.Taxcom.Models;

public struct TaxcomKKT
{
	[JsonPropertyName("name")]
	public string Name {get; set;}
	
	[JsonPropertyName("kktRegNumber")]
	public string RegNumber {get; set;}
	
	[JsonPropertyName("kktFactoryNumber")]
	public string Serial {get; set;}
	
	[JsonPropertyName("fnFactoryNumber")]
	public string StorageSerial {get; set;}
	
	[JsonPropertyName("cashdeskState")]
	public TaxcomKKTState State {get; set;}
}