using System;
using System.Text.Json;
using Xunit;

namespace JsonConverters.Tests
{
    public class NullableIsoDateConverterTests
    {
        private readonly NullableIsoDateConverter _converter = new NullableIsoDateConverter();

        [Fact]
        public void Read_Returns_NullableDatetime_WhenHasValue()
        {
            DateTime? dateTime = DateTime.UtcNow;
            byte[] bytes = JsonSerializer.SerializeToUtf8Bytes(dateTime);

            Utf8JsonReader reader = new Utf8JsonReader(bytes);
            reader.Read();
            DateTime? output = _converter.Read(ref reader, typeof(DateTime?), null);
            
            Assert.NotNull(output);
            Assert.Equal(dateTime.Value.Date, output.Value.Date);
        }
        
        [Fact]
        public void Read_Returns_Null_WhenNotHasValue()
        {
            DateTime? dateTime = null;
            byte[] bytes = JsonSerializer.SerializeToUtf8Bytes(dateTime);

            Utf8JsonReader reader = new Utf8JsonReader(bytes);
            reader.Read();
            DateTime? output = _converter.Read(ref reader, typeof(DateTime?), null);
            
            Assert.Null(output);
        }
    }
}