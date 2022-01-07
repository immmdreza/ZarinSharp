using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using ZarinSharp.Types.Enums;

namespace ZarinSharp.Converters
{
    internal class FeeTypeConverter : JsonConverter<FeeType>
    {
        public override FeeType Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options) => reader.GetString() switch
            {
                "Merchant" => FeeType.Merchant,
                "Payer" => FeeType.Payer,
                _ => FeeType.UnknownGuy
            };

        public override void Write(
            Utf8JsonWriter writer,
            FeeType value,
            JsonSerializerOptions options) => writer.WriteStringValue(value switch
            {
                FeeType.Merchant => "Merchant",
                FeeType.Payer => "Payer",
                _ => throw new JsonException()
            });
    }
}
