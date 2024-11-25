using EfCore.NamingConverter.Converters;

namespace EfCore.NamingConverter.Tests.Converters
{
    public class SeparatorConverterTest
    {
        class MySeparatorConverter : SeparatorConverter
        {
            public MySeparatorConverter() : base(lowercase: true, separator: '_')
            {
            }
        }

        [Fact]
        public void CanConvertNameToSnakeCaseLower()
        {
            var converter = new MySeparatorConverter();
            Assert.Equal("snake_case_lower", converter.ConvertName("SnakeCaseLower"));
        }
    }
}
