namespace Recify.Parsers.Taxcom.Models;

/// <summary>Информация о торговой точке</summary>
public struct TaxcomOutlet
{
    /// <summary>Идентификатор торговой точки</summary>
    [JsonPropertyName("id")]
	public string Id {get; set;}

    /// <summary>Название торговой точки</summary>
    [JsonPropertyName("name")]
	public string Name {get; set;}

    /// <summary>Код торговой точки</summary>
    [JsonPropertyName("code")]
	public string Code {get; set;}

    /// <summary>Адрес торговой точки</summary>
    [JsonPropertyName("address")]
	public string Address {get; set;}
}