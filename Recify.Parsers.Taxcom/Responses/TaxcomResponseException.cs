namespace Recify.Parsers.Taxcom.Responses;

public class TaxcomResponseException: Exception
{
	[JsonPropertyName("httpErrorCode")]
	public short HTTPCode {get; set;}
	
	[JsonPropertyName("apiErrorCode")]
	public short APICode {get; set;}

	[JsonPropertyName("commonDescription")]
	public string CommonDescription { get; set; } = "";

	[JsonPropertyName("details")]
	public string Details { get; set; } = "";
	
	public override string ToString() => 
		$"[{HTTPCode}/{APICode}] {CommonDescription}: {Details}";
}