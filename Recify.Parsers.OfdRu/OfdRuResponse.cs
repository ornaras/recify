using System.Text.Json.Serialization;

namespace Recify.Parsers.OfdRu
{
    /// <summary>Структура ответа OFD.ru</summary>
    public struct OfdRuResponse<T>
    {
        /// <summary>Состояние обработки запроса.</summary>
        public OfdRuResponseStatus Status { get; set; }
        /// <summary>Перечисление данных.</summary>
        public IEnumerable<T> Data { get; set; }
        /// <summary>Перечисление ошибок.</summary>
        public IEnumerable<string> Errors { get; set; }
        /// <summary>Время, затраченное на обработку запроса.</summary>
        public TimeSpan Elapsed { get; set; }

        /// <summary>Возвращает true, если запрос успешно отработан, иначе false</summary>
        [JsonIgnore]
        public readonly bool Success => Status == OfdRuResponseStatus.Success;

        /// <summary>Формирует экземпляр исключения</summary>
        public readonly Exception ToException() =>
            new($"Запрос выполнен с ошибками: {string.Join(", ", Errors)}");
    }
}
