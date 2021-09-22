using System;
using System.Text.Json;
using Xunit;

namespace JsonConverters.Tests
{
    public class IsoDateConverterTests
    {
        private readonly IsoDateConverter _converter = new IsoDateConverter();

        [Fact]
        public void Read_Returns_Datetime()
        {
            DateTime dateTime = DateTime.UtcNow;
            byte[] bytes = JsonSerializer.SerializeToUtf8Bytes(dateTime);

            Utf8JsonReader reader = new Utf8JsonReader(bytes);
            reader.Read();
            DateTime output = _converter.Read(ref reader, typeof(DateTime), null);
            
            Assert.Equal(dateTime.Date, output.Date);
        }
    }
}