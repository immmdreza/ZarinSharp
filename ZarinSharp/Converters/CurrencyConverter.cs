using System.Text.Json;
using System.Text.Json.Serialization;
using ZarinSharp.Types.Enums;

namespace ZarinSharp.Converters
{
    public class CurrencyConverter : JsonConverter<Currency>
    {
        public override Currency Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return reader.GetString() switch
            {
                "IRR" => Currency.IRR,
                "IRT" => Currency.IRT,
                _ => throw new JsonException()
            };
        }

        public override void Write(Utf8JsonWriter writer, Currency value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value switch
            {
                Currency.IRR => "IRR",
                Currency.IRT => "IRT",
                _ => throw new JsonException()
            });
        }
    }
}
