namespace Recify.Parsers.Taxcom.Models;

public struct TaxcomDocument
{
	[JsonPropertyName("fnFactoryNumber")]
	public string Storage {get; set;}
	
	[JsonPropertyName("shiftNumber")]
	public int ShiftNumber {get; set;}
	
	[JsonPropertyName("documentType")]	
	public TaxcomDocType Type {get; set;}
	
	[JsonPropertyName("datetime")]
	public DateTime DateTime {get; set;}
	
	[JsonPropertyName("fdNumber")]
	public int Number {get; set;}
	
	[JsonPropertyName("numberInShift")]
	public int NumberInShift {get; set;}
	
	[JsonPropertyName("fpd")]
	public string Sign {get; set;}
	
	[JsonPropertyName("cashier")]
	public string Operator {get; set;}
	
	[JsonPropertyName("taxationSystem")]
	public TaxcomTaxationSystem? TaxationSystem {get; set;}
	
	[JsonPropertyName("sum")]
	public ulong Sum {get; set;}
	
	[JsonPropertyName("cash")]
	public ulong SumCash {get; set;}
	
	[JsonPropertyName("electronic")]
	public ulong SumEcash {get; set;}
	
	[JsonPropertyName("nondsSum")]
	public ulong SumNoVAT {get; set;}
	
	[JsonPropertyName("nds0Sum")]
	public ulong SumVAT0 {get; set;}
	
	[JsonPropertyName("nds10")]
	public ulong SumVAT10 {get; set;}
	
	[JsonPropertyName("nds18")]
	public ulong SumVAT18 {get; set;}
	
	[JsonPropertyName("nds20")]
	public ulong SumVAT20 {get; set;}
	
	[JsonPropertyName("ndsC10")]
	public ulong SumVAT110 {get; set;}
	
	[JsonPropertyName("ndsC18")]
	public ulong SumVAT118 {get; set;}
	
	[JsonPropertyName("ndsC20")]
	public ulong SumVAT120 {get; set;}
	
	[JsonPropertyName("nds5")]
	public ulong SumVAT5 {get; set;}
	
	[JsonPropertyName("nds7")]
	public ulong SumVAT7 {get; set;}
	
	[JsonPropertyName("ndsC5")]
	public ulong SumVAT105 {get; set;}
	
	[JsonPropertyName("ndsC7")]
	public ulong SumVAT107 {get; set;}
}