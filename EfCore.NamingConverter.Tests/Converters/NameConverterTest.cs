using EfCore.NamingConverter.Converters;

namespace EfCore.NamingConverter.Tests.Converters
{
    public class NameConverterTest
    {
        [Theory]
        [InlineData(NamingPolicy.CamelCase, "FullName", "fullName")]
        [InlineData(NamingPolicy.SnakeCaseLower, "FullName", "full_name")]
        [InlineData(NamingPolicy.SnakeCaseUpper, "FullName", "FULL_NAME")]
        [InlineData(NamingPolicy.KebabCaseLower, "FullName", "full-name")]
        [InlineData(NamingPolicy.KebabCaseUpper, "FullName", "FULL-NAME")]
        [InlineData(NamingPolicy.Unspecified, "FullName", "FullName")]
        public void CanConvertName(NamingPolicy namingPolicy, string input, string expected)
        {
            var converter = NameConverter.From(namingPolicy);
            Assert.Equal(expected, converter.ConvertName(input));
        }
    }
}
