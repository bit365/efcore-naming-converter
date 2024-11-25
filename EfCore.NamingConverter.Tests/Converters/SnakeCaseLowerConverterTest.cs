using EfCore.NamingConverter.Converters;

namespace EfCore.NamingConverter.Tests.Converters
{
    public class SnakeCaseLowerConverterTest
    {
        [Fact]
        public void CanConvertNameToSnakeCaseLower()
        {
            var converter = new SnakeCaseLowerConverter();
            Assert.Equal("snake_case_lower", converter.ConvertName("SnakeCaseLower"));
        }
    }
}
