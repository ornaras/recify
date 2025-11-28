using System.Text.Json.Nodes;

namespace Recify.Parsers.Taxcom.Responses;

/// <summary>Подробная информация о документе</summary>
public struct TaxcomDetailDocumentResponse
{
    /// <summary>Дата формирования ответа</summary>
	[JsonPropertyName("reportDate")]
	public DateTime Date { get; set; }

    /// <summary>Дата формата фискального документа</summary>
    [JsonPropertyName("documentFormatDate")]
	public string FormatDate { get; set; }

    /// <summary>Формат фискального документа</summary>
    [JsonPropertyName("documentFormatVersion")]
	public string Format { get; set; }

    /// <summary>Тип документа</summary>
    [JsonPropertyName("documentType")]
	public TaxcomDocType DocumentType { get; set; }

    /// <summary>Информация о документе</summary>
    [JsonPropertyName("document")]
	public JsonNode Document { get; set; }

    /// <summary>Фискальный признак документа</summary>
    [JsonIgnore]
	public readonly uint Sign 
	{
		get
		{
			var text = Document["1077"]!.GetValue<string>();
			var bytes = Convert.FromBase64String(text);
			Array.Reverse(bytes, 2, 4);
			return BitConverter.ToUInt32(bytes, 2);
		}
	}
}
