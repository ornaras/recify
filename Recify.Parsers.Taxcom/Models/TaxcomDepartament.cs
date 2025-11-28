namespace Recify.Parsers.Taxcom.Models;

/// <summary>Информация о подразделении</summary>
public struct TaxcomDepartament
{
    /// <summary>Идентификатор подразделения</summary>
    [JsonPropertyName("id")]
	public string Id {get; set;}

    /// <summary>Название подразделения</summary>
    [JsonPropertyName("name")]
	public string Name {get; set;}

    /// <summary>Код подразделения</summary>
    [JsonPropertyName("code")]
	public string Code {get; set;}
}