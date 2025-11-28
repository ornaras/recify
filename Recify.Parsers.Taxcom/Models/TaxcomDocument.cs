namespace Recify.Parsers.Taxcom.Models;

/// <summary>Краткая информация о документе</summary>
public struct TaxcomDocument
{
    /// <summary>Номер фискального накопителя</summary>
	[JsonPropertyName("fnFactoryNumber")]
	public string Storage {get; set;}

    /// <summary>Номер смены</summary>
    [JsonPropertyName("shiftNumber")]
	public int ShiftNumber {get; set;}

    /// <summary>Тип документа</summary>
    [JsonPropertyName("documentType")]	
	public TaxcomDocType Type {get; set;}

    /// <summary>Дата и время</summary>
    [JsonPropertyName("datetime")]
	public DateTime DateTime {get; set;}

    /// <summary>Номер фискального документа</summary>
    [JsonPropertyName("fdNumber")]
	public int Number {get; set;}

    /// <summary>Номер документа за смену</summary>
    [JsonPropertyName("numberInShift")]
	public int NumberInShift {get; set;}

    /// <summary>Фискальный признак документа</summary>
    [JsonPropertyName("fpd")]
	public string Sign {get; set;}

    /// <summary>Кассир</summary>
    [JsonPropertyName("cashier")]
	public string Operator {get; set;}

    /// <summary>Система налогообложения</summary>
    [JsonPropertyName("taxationSystem")]
	public TaxcomTaxationSystem? TaxationSystem {get; set;}

    /// <summary>Сумма (в копейках)</summary>
    [JsonPropertyName("sum")]
	public ulong Sum {get; set;}

    /// <summary>Сумма наличной оплаты (в копейках)</summary>
    [JsonPropertyName("cash")]
	public ulong SumCash {get; set;}

    /// <summary>Сумма безналичной оплаты (в копейках)</summary>
    [JsonPropertyName("electronic")]
	public ulong SumEcash {get; set;}

    /// <summary>Сумма без НДС (в копейках)</summary>
    [JsonPropertyName("nondsSum")]
	public ulong SumNoVAT {get; set;}

    /// <summary>Сумма НДС 0% (в копейках)</summary>
    [JsonPropertyName("nds0Sum")]
	public ulong SumVAT0 {get; set;}

    /// <summary>Сумма НДС 10% (в копейках)</summary>
    [JsonPropertyName("nds10")]
	public ulong SumVAT10 {get; set;}

    /// <summary>Сумма НДС 18% (в копейках)</summary>
    [JsonPropertyName("nds18")]
	public ulong SumVAT18 {get; set;}

    /// <summary>Сумма НДС 20% (в копейках)</summary>
    [JsonPropertyName("nds20")]
	public ulong SumVAT20 {get; set;}

    /// <summary>Сумма НДС 10/110 (в копейках)</summary>
    [JsonPropertyName("ndsC10")]
	public ulong SumVAT110 {get; set;}

    /// <summary>Сумма НДС 18/118 (в копейках)</summary>
    [JsonPropertyName("ndsC18")]
	public ulong SumVAT118 {get; set;}

    /// <summary>Сумма НДС 20/120 (в копейках)</summary>
    [JsonPropertyName("ndsC20")]
	public ulong SumVAT120 {get; set;}

    /// <summary>Сумма НДС 5% (в копейках)</summary>
    [JsonPropertyName("nds5")]
	public ulong SumVAT5 {get; set;}

    /// <summary>Сумма НДС 7% (в копейках)</summary>
    [JsonPropertyName("nds7")]
	public ulong SumVAT7 {get; set;}

    /// <summary>Сумма НДС 5/105 (в копейках)</summary>
    [JsonPropertyName("ndsC5")]
	public ulong SumVAT105 {get; set;}

    /// <summary>Сумма НДС 7/107 (в копейках)</summary>
    [JsonPropertyName("ndsC7")]
	public ulong SumVAT107 {get; set;}
}