using EfCore.NamingConverter.Converters;

namespace EfCore.NamingConverter.Tests.Converters
{
    public class CamelCaseConverterTest
    {
        [Fact]
        public void CanConvertNameToCamelCase()
        {
            var converter = new CamelCaseConverter();

            Assert.Equal("camelCaseName", converter.ConvertName("CamelCaseName"));
        }
    }
}
