using EfCore.NamingConverter.Converters;

namespace EfCore.NamingConverter.Tests.Converters
{
    public class KebabCaseUpperConverterTest
    {
        [Fact]
        public void CanConvertNameToKebabCaseUpper()
        {
            var converter = new KebabCaseUpperConverter();

            Assert.Equal("SNAKE-CASE-LOWER", converter.ConvertName("SnakeCaseLower"));
        }
    }
}
