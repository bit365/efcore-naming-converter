using EfCore.NamingConverter.Converters;

namespace EfCore.NamingConverter.Tests.Converters
{
    public class KebabCaseLowerConverterTest
    {
        [Fact]
        public void CanConvertNameToKebabCaseLower()
        {
            var converter = new KebabCaseLowerConverter();

            Assert.Equal("kebab-case-lower", converter.ConvertName("KebabCaseLower"));
        }
    }
}
