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
        public void ConvertName_ShouldReturnSnakeCaseLower()
        {
            var converter = new MySeparatorConverter();
            Assert.Equal("full_name", converter.ConvertName("FullName"));
        }
    }
}
