using Recify.Parsers.Taxcom.Converters;

namespace Recify.Parsers.Taxcom;

/// <summary>Признак наличия проблемы</summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum TaxcomProblemStatus
{
    /// <summary>Нет проблем</summary>
    OK,
    /// <summary>Предупреждение</summary>
    Warning,
    /// <summary>Есть проблема</summary>
    Problem
}

/// <summary>Статус фискального накопителя</summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum TaxcomStorageStatus
{
    /// <summary>Активен</summary>
    Active,
    /// <summary>Отключен</summary>
    Notactive
}

/// <summary>Состояние ККТ</summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum TaxcomKKTState
{
    /// <summary>Подключена</summary>
    Active,
    /// <summary>Заканчивается оплата</summary> 
    Expires,
    /// <summary>Не оплачена</summary>
    Expired,
    /// <summary>Отключена пользователем</summary>
    Inactive,
    /// <summary>Подключение</summary>
    Activation,
    /// <summary>Отключение</summary>
    Deactivation,
    /// <summary>Замена ФН</summary>
    FNChange,
    /// <summary>Регистрация в ФНС</summary>
    FNSRegistration,
    /// <summary>Ошибка регистрации в ФНС</summary>
    FNSRegistrationError
}

/// <summary>Система налогообложения</summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum TaxcomTaxationSystem
{
    /// <summary>ОСН</summary>
    OSN,
    /// <summary>УСН доход</summary>
    USNIncome,
    /// <summary>УСН доход-расход</summary>
    USNIncomeExpenditure,
    /// <summary>ЕНВД</summary>
    ENVD,
    /// <summary>ЕСН</summary>
    ESN,
    /// <summary>Патент</summary>
    Patent
}

/// <summary>Тип документа</summary>
[JsonConverter(typeof(TaxcomDocTypeConverter))]
public enum TaxcomDocType
{
    /// <summary>Отчет об открытии смены</summary>
    OpenSessionReport = 2,
    /// <summary>Отчет о текущем состоянии расчетов</summary>
    CurrentStatusReport = 21,
    /// <summary>Кассовый чек</summary>
    Receipt = 3,
    /// <summary>Кассовый чек коррекции</summary>
    CorrectionReceipt = 31,
    /// <summary>Бланк строгой отчетности</summary>
    BSO = 4,
    /// <summary>Бланк строгой отчетности коррекции</summary>
    CorrectionBSO = 41,
	/// <summary>Отчет о закрытии смены</summary>
	CloseSessionReport = 5
}