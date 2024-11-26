using EfCore.NamingConverter.Converters;

namespace EfCore.NamingConverter.Tests.Converters
{
    public class KebabCaseLowerConverterTest
    {
        [Fact]
        public void ConvertName_ShouldReturnKebabCaseLower()
        {
            // Arrange
            var kebabCaseConverter = new KebabCaseLowerConverter();

            // Act
            var actual = kebabCaseConverter.ConvertName("FullName");

            // Assert
            Assert.Equal("full-name", actual);
        }

        [Fact]
        public void ConvertName_InputEmpty_ShouldReturnEmpty()
        {
            // Arrange
            var kebabCaseConverter = new KebabCaseLowerConverter();

            // Act
            var actual = kebabCaseConverter.ConvertName(string.Empty);

            // Assert
            Assert.Equal(string.Empty, actual);
        }
    }
}
