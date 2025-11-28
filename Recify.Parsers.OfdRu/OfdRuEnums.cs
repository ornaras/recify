using System.Text.Json.Serialization;

namespace Recify.Parsers.OfdRu;

/// <summary>Состояние обработки запроса.</summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum OfdRuResponseStatus
{
    /// <summary>Запрос обработан успешно.</summary>
    Success,
    /// <summary>Обработка запроса не удалась.</summary>
    Failed
}
