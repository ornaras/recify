namespace Recify.Parsers.Taxcom.Responses;

internal struct TaxcomAuthResponse
{
	[JsonPropertyName("sessionToken")]
	public string SessionToken {get; set;}
}