namespace Recify.Parsers.OfdRu;

/// <summary>API-клиент OFD.ru</summary>
public class OfdRuClient: HttpClient
{
    /// <summary>Инициализирует новый экземпляр <see cref="OfdRuClient"/>.</summary>
    public OfdRuClient()
    {
        BaseAddress = new Uri("https://ofd.ru/api/integration/v2/");
    }
}
