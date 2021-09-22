using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace JsonConverters
{
    public class NullableIsoDateConverter : JsonConverter<DateTime?>
    {
        public override DateTime? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            bool wasParsed = DateTime.TryParse(reader.GetString(), out DateTime value);
            return wasParsed ? value : (DateTime?)null;
        }

        public override void Write(Utf8JsonWriter writer, DateTime? value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value?.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture));
        }
    }
}