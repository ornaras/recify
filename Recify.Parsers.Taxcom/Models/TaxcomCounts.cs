namespace Recify.Parsers.Taxcom.Models;

/// <summary>Информация о кол-ве записей</summary>
public struct TaxcomCounts
{
    /// <summary>Общее кол-во записей</summary>
    [JsonPropertyName("recordCount")]
	public int TotalCount {get; set;}

    /// <summary>Кол-во записей с учетом фильтра</summary>
    [JsonPropertyName("recordFilteredCount")]
	public int FilteredCount {get; set;}

    /// <summary>Кол-во записей в ответе</summary>
    [JsonPropertyName("recordInResponceCount")]
	public int Count {get; set;}
}