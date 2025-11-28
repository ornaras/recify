#pragma warning disable S101
namespace Recify.Parsers.Taxcom.Models;

/// <summary>Информация о ККТ</summary>
public struct TaxcomKKT
{
    /// <summary>Название ККТ</summary>
    [JsonPropertyName("name")]
	public string Name {get; set;}

    /// <summary>Регистрационный номер ККТ</summary>
    [JsonPropertyName("kktRegNumber")]
	public string RegNumber {get; set;}

    /// <summary>Заводской номер ККТ</summary>
    [JsonPropertyName("kktFactoryNumber")]
	public string Serial {get; set;}

    /// <summary>Номер актуального фискального накопителя</summary>
    [JsonPropertyName("fnFactoryNumber")]
	public string StorageSerial {get; set;}

    /// <summary>Состояние ККТ</summary>
    [JsonPropertyName("cashdeskState")]
	public TaxcomKKTState State {get; set;}
}