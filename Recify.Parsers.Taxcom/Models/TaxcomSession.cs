namespace Recify.Parsers.Taxcom.Models;

public struct TaxcomSession
{
	[JsonPropertyName("fnFactoryNumber")]
	public string StorageNumber {get; set;}
	
	[JsonPropertyName("shiftNumber")]
	public int Number {get; set;}
	
	[JsonPropertyName("openDateTime")]
	public DateTime Opened {get; set;}
	
	[JsonPropertyName("closeDateTime")]
	public DateTime Closed {get; set;}
	
	[JsonPropertyName("receiptCount")]
	public int ReceiptCount {get; set;}
}