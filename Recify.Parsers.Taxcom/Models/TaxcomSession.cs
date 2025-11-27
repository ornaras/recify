namespace Recify.Parsers.Taxcom.Models;

/// <summary>Информация о смене</summary>
public struct TaxcomSession
{
    /// <summary>Номер фискального накопителя</summary>
    [JsonPropertyName("fnFactoryNumber")]
	public string StorageNumber {get; set;}

    /// <summary>Номер смены</summary>
    [JsonPropertyName("shiftNumber")]
	public int Number {get; set;}

    /// <summary>Дата открытия</summary>
    [JsonPropertyName("openDateTime")]
	public DateTime Opened {get; set;}

    /// <summary>Дата закрытия</summary>
    [JsonPropertyName("closeDateTime")]
	public DateTime Closed {get; set;}

    /// <summary>Кол-во чеков за смену</summary>
    [JsonPropertyName("receiptCount")]
	public int ReceiptCount {get; set;}
}