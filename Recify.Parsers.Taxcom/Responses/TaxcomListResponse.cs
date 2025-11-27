using Recify.Parsers.Taxcom.Models;

namespace Recify.Parsers.Taxcom.Responses;

/// <summary>Информация о списке</summary>
public struct TaxcomListResponse<T>
{
    /// <summary>Дата формирования ответа</summary>
	[JsonPropertyName("reportDate")]
	public DateTime Date {get; set;}

    /// <summary>Информация о кол-ве записей</summary>
    [JsonPropertyName("counts")]
	public TaxcomCounts Counts {get; set;}

    /// <summary>Список записей</summary>
    [JsonPropertyName("records")]
	public IEnumerable<T> Items {get; set;}
}