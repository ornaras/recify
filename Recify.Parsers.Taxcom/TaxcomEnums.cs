using Recify.Parsers.Taxcom.Converters;

namespace Recify.Parsers.Taxcom;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum TaxcomProblemStatus {OK, Warning, Problem}

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum TaxcomStorageStatus {Active, Notactive}

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum TaxcomKKTState {Active, Expires, Expired, Inactive, Activation, Deactivation, FNChange, FNSRegistration, FNSRegistrationError}

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum TaxcomTaxationSystem {OSN, USNIncome, USNIncomeExpenditure, ENVD, ESN, Patent}

[JsonConverter(typeof(TaxcomDocTypeConverter))]
public enum TaxcomDocType
{
	OpenSessionReport = 2,
	CurrentStatusReport = 21,
	Receipt = 3,
	CorrectionReceipt = 31,
	BSO = 4,
	CorrectionBSO = 41,
	CloseSessionReport = 5
}