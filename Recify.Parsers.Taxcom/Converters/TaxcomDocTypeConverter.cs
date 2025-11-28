using System.Text.Json;

namespace Recify.Parsers.Taxcom.Converters;

internal class TaxcomDocTypeConverter : JsonConverter<TaxcomDocType>
{
    public override TaxcomDocType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) => 
        (TaxcomDocType)int.Parse(reader.GetString()!);

    public override void Write(Utf8JsonWriter writer, TaxcomDocType value, JsonSerializerOptions options){}
}