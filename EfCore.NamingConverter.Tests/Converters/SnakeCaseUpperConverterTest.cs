using EfCore.NamingConverter.Converters;

namespace EfCore.NamingConverter.Tests.Converters
{
    public class SnakeCaseUpperConverterTest
    {
        [Fact]
        public void CanConvertNameToSnakeCaseUpper()
        {
            var converter = new SnakeCaseUpperConverter();

            Assert.Equal("SNAKE_CASE_NAME", converter.ConvertName("SnakeCaseName"));
        }
    }
}
