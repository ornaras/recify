using System.Text.Json.Nodes;

namespace Recify.Parsers.Taxcom.Responses;

public struct TaxcomDetailDocumentResponse
{
	[JsonPropertyName("reportDate")]
	public DateTime Date { get; set; }
	
	[JsonPropertyName("documentFormatDate")]
	public string FormatDate { get; set; }
	
	[JsonPropertyName("documentFormatVersion")]
	public string Format { get; set; }
	
	[JsonPropertyName("documentType")]
	public TaxcomDocType DocumentType { get; set; }
	
	[JsonPropertyName("document")]
	public JsonNode Document { get; set; }
	
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
