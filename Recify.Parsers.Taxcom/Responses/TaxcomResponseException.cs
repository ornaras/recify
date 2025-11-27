namespace Recify.Parsers.Taxcom.Responses;

/// <summary>Сообщение об ошибке</summary>
public class TaxcomResponseException: Exception
{
    /// <summary>Код HTTP</summary>
    [JsonPropertyName("httpErrorCode")]
	public short HTTPCode {get; set;}

    /// <summary>Код API</summary>
    [JsonPropertyName("apiErrorCode")]
	public short APICode {get; set;}

    /// <summary>Общее описание</summary>
    [JsonPropertyName("commonDescription")]
	public string CommonDescription { get; set; } = "";

    /// <summary>Детальная информация</summary>
    [JsonPropertyName("details")]
	public string Details { get; set; } = "";

    /// <summary>Формирует текстовое представление исключения в компактном виде</summary>
    public override string ToString() => 
		$"[{HTTPCode}/{APICode}] {CommonDescription}: {Details}";
}