using System.Text;
using System.Net.Http.Json;
using Recify.Parsers.Taxcom.Models;
using Recify.Parsers.Taxcom.Responses;

namespace Recify.Parsers.Taxcom;

/// <summary>
/// API-клиент Такском-Касса
/// </summary>
public class TaxcomClient : HttpClient
{
    /// <summary>
    /// Инициализирует новый экземпляр <see cref="TaxcomClient"/>
    /// </summary>
    /// <param name="integratorId">Идентификатор интегратора</param>
    /// <param name="test">true, если использовать тестовый сервер, иначе false</param>
    /// <param name="version">Версия API</param>
    public TaxcomClient(string integratorId, bool test = false, string version = "v2") : base()
	{
		BaseAddress = new Uri($"https://{(test?"api-tlk-ofd":"api-lk-ofd")}.taxcom.ru/API/{version}/");
		DefaultRequestHeaders.Add("Integrator-ID", integratorId);
	}

    /// <summary>
    /// Выполнить аутентификацию и авторизацию.
    /// </summary>
    /// <param name="login">Логин</param>
    /// <param name="password">Пароль</param>
    /// <param name="agreementNumber">Номер договора</param>
    /// <param name="cancel">Токен, с помощью которого вызывающий код может запросить отмену выполнения метода</param>
    public async Task AuthAsync
        (string login, string password, string? agreementNumber = null, CancellationToken cancel = default)
	{
        var authData = new { login, password, agreementNumber };
		using var req = new HttpRequestMessage(HttpMethod.Post, "Login");
		req.Content = JsonContent.Create(authData);
		using var resp = await SendAsync(req, cancel);
        if (!resp.IsSuccessStatusCode) throw await ParseError(resp);
        var tokenData = await resp.Content.ReadFromJsonAsync<TaxcomAuthResponse>(cancel);
		DefaultRequestHeaders.Remove("Session-Token");
		DefaultRequestHeaders.Add("Session-Token", tokenData.SessionToken);
    }

    /// <summary>
    /// Получить список подразделений.
    /// </summary>
    /// <param name="page">Номер страницы результатов</param>
    /// <param name="pageSize">Кол-во результатов на странице</param>
    /// <param name="ps">Фильтр по признаку наличия проблемы</param>
    /// <param name="cancel">Токен, с помощью которого вызывающий код может запросить отмену выполнения метода</param>
    /// <returns>Список подразделений</returns>
    public async Task<TaxcomListResponse<TaxcomDepartament>> FetchDepartmentsAsync
        (uint page = 1, ushort pageSize = 100, TaxcomProblemStatus? ps = null, CancellationToken cancel = default)
    {
        var builder = new StringBuilder($"DepartmentList?ps={pageSize}&pn={page}");
        if (ps is not null) builder.Append($"&np={ps:G}");
        using var resp = await GetAsync(builder.ToString(), cancel);
        if (!resp.IsSuccessStatusCode) throw await ParseError(resp);
        return await resp.Content.ReadFromJsonAsync<TaxcomListResponse<TaxcomDepartament>>(cancel);
    }

    /// <summary>
    /// Получить список торговых точек.
    /// </summary>
    /// <param name="page">Номер страницы результатов</param>
    /// <param name="pageSize">Кол-во результатов на странице</param>
    /// <param name="ps">Фильтр по признаку наличия проблемы</param>
    /// <param name="id">Идентификатор подразделения</param>
    /// <param name="cancel">Токен, с помощью которого вызывающий код может запросить отмену выполнения метода</param>
    /// <returns>Список торговых точек</returns>
    public async Task<TaxcomListResponse<TaxcomOutlet>> FetchOutletsAsync
        (uint page = 1, ushort pageSize = 100, int? id = null, TaxcomProblemStatus? ps = null, CancellationToken cancel = default)
    {
        var builder = new StringBuilder($"OutletList?ps={pageSize}&pn={page}");
        if (ps is not null) builder.Append($"&np={ps:G}");
        if (id is not null) builder.Append($"&id={id}");
        using var resp = await GetAsync(builder.ToString(), cancel);
        if (!resp.IsSuccessStatusCode) throw await ParseError(resp);
        return await resp.Content.ReadFromJsonAsync<TaxcomListResponse<TaxcomOutlet>>(cancel);
    }

    /// <summary>
    /// Получение списка ККТ, которые относятся к определенной торговой точке.
    /// </summary>
    /// <param name="outletId">Идентификатор торговой точки</param>
    /// <param name="page">Номер страницы результатов</param>
    /// <param name="pageSize">Кол-во результатов на странице</param>
    /// <param name="ps">Фильтр по признаку наличия проблемы</param>
    /// <param name="cancel">Токен, с помощью которого вызывающий код может запросить отмену выполнения метода</param>
    /// <returns>Список ККТ</returns>
    public async Task<TaxcomListResponse<TaxcomKKT>> FetchKKTsAsync
        (string outletId, uint page = 1, ushort pageSize = 100, TaxcomProblemStatus? ps = null, CancellationToken cancel = default)
	{
		var builder = new StringBuilder($"KKTList?id={outletId}&ps={pageSize}&pn={page}");
		if(ps is not null) builder.Append($"&np={ps:G}");
		using var resp = await GetAsync(builder.ToString(), cancel);
        if (!resp.IsSuccessStatusCode) throw await ParseError(resp);
        return await resp.Content.ReadFromJsonAsync<TaxcomListResponse<TaxcomKKT>>(cancel);
	}

    /// <summary>
    /// Получить список номеров фискальных нокопилей.
    /// </summary>
    /// <param name="regNumber">Регистрационный номер ККТ</param>
    /// <param name="status">Фильтр по статусу ФН</param>
    /// <param name="cancel">Токен, с помощью которого вызывающий код может запросить отмену выполнения метода</param>
    /// <returns>Список номеров фискальных накопителей</returns>
    public async Task<TaxcomListResponse<string>> FetchStoragesAsync
		(string regNumber, TaxcomStorageStatus status = 0, CancellationToken cancel = default)
	{
		using var resp = await GetAsync($"FnHistory?kktRegNumber={regNumber}&np={status:G}", cancel);
        if (!resp.IsSuccessStatusCode) throw await ParseError(resp);
		var _ = await resp.Content.ReadFromJsonAsync<TaxcomListResponse<TaxcomStorage>>(cancel);
		return new TaxcomListResponse<string>()
		{
			Counts = _.Counts,
			Date = _.Date,
			Items = _.Items.Select(x => x.Number)
		};

    }

    /// <summary>
    /// Получить список смен за период по ККТ.
    /// </summary>
    /// <param name="fn">Номер фискального накопителя</param>
    /// <param name="begin">Начало периода</param>
    /// <param name="end">Окончание периода</param>
    /// <param name="page">Номер страницы результатов</param>
    /// <param name="pageSize">Кол-во результатов на странице</param>
    /// <param name="cancel">Токен, с помощью которого вызывающий код может запросить отмену выполнения метода</param>
    /// <returns>Список смен</returns>
    public async Task<TaxcomListResponse<TaxcomSession>> FetchSessionsAsync
        (string fn, DateTime begin, DateTime end, uint page = 1, ushort pageSize = 100, CancellationToken cancel = default)
	{
		var builder = new StringBuilder($"ShiftList?fn={fn}&ps={pageSize}&pn={page}");
		builder.Append($"&begin={begin:yyyy-MM-ddTHH':'mm':'ss}");
		builder.Append($"&end={end:yyyy-MM-ddTHH':'mm':'ss}");
		using var resp = await GetAsync(builder.ToString(), cancel);
		if(!resp.IsSuccessStatusCode) throw await ParseError(resp);
		return await resp.Content.ReadFromJsonAsync<TaxcomListResponse<TaxcomSession>>(cancel);
	}

    /// <summary>
    /// Получить краткую информацию по чекам за смену.
    /// </summary>
    /// <param name="fn">Номер фискального накопителя</param>
    /// <param name="session">Номер смены</param>
    /// <param name="page">Номер страницы результатов</param>
    /// <param name="pageSize">Кол-во результатов на странице</param>
    /// <param name="types">Тип документа</param>
    /// <param name="cancel">Токен, с помощью которого вызывающий код может запросить отмену выполнения метода</param>
    /// <returns>Список документов</returns>
    public async Task<TaxcomListResponse<TaxcomDocument>> FetchDocumentsAsync
        (string fn, int session, uint page = 1, ushort pageSize = 100, CancellationToken cancel = default, params TaxcomDocType[] types)
	{
		var builder = new StringBuilder($"DocumentList?fn={fn}&shift={session}&ps={pageSize}&pn={page}");
		foreach(var type in types) builder.Append($"&type={type:D}");
		using var resp = await GetAsync(builder.ToString(), cancel);
		if(!resp.IsSuccessStatusCode) throw await ParseError(resp);
		return await resp.Content.ReadFromJsonAsync<TaxcomListResponse<TaxcomDocument>>(cancel);
	}

    /// <summary>
    /// Получить содержимое документа.
    /// </summary>
    /// <param name="fn">Номер фискального накопителя</param>
    /// <param name="docNumber">Номер фискального документа</param>
    /// <param name="cancel">Токен, с помощью которого вызывающий код может запросить отмену выполнения метода</param>
    /// <returns>Информация о документе</returns>
    public async Task<TaxcomDetailDocumentResponse> FetchDocumentInfoAsync
		(string fn, int docNumber, CancellationToken cancel = default)
	{
		using var resp = await GetAsync($"DocumentInfo?fn={fn}&fd={docNumber}", cancel);
		if(!resp.IsSuccessStatusCode) throw await ParseError(resp);
		return await resp.Content.ReadFromJsonAsync<TaxcomDetailDocumentResponse>(cancel);
	}

	private static async Task<TaxcomResponseException> ParseError(HttpResponseMessage resp) =>
        (await resp.Content.ReadFromJsonAsync<TaxcomResponseException>())!;
}