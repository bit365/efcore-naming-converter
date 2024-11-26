using EfCore.NamingConverter.Converters;

namespace EfCore.NamingConverter.Tests.Converters
{
    public class CamelCaseConverterTest
    {
        [Fact]
        public void ConvertName_ShouldReturnCamelCase()
        {
            // Arrange
            var camelCaseConverter = new CamelCaseConverter();

            // Act
            var actual = camelCaseConverter.ConvertName("FullName");

            // Assert
            Assert.Equal("fullName", actual);
        }

        [Fact]
        public void ConvertName_InputEmpty_ShouldReturnEmpty()
        {
            // Arrange
            var camelCaseConverter = new CamelCaseConverter();

            // Act
            var actual = camelCaseConverter.ConvertName(string.Empty);

            // Assert
            Assert.Equal(string.Empty, actual);
        }
    }
}
