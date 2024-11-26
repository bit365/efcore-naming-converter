using EfCore.NamingConverter.Converters;

namespace EfCore.NamingConverter.Tests.Converters
{
    public class KebabCaseUpperConverterTest
    {
        [Fact]
        public void ConvertName_ShouldReturnKebabCaseUpper()
        {
            // Arrange
            var kebabCaseConverter = new KebabCaseUpperConverter();

            // Act
            var actual = kebabCaseConverter.ConvertName("FullName");

            // Assert
            Assert.Equal("FULL-NAME", actual);
        }

        [Fact]
        public void ConvertName_InputEmpty_ShouldReturnEmpty()
        {
            // Arrange
            var kebabCaseConverter = new KebabCaseUpperConverter();

            // Act
            var actual = kebabCaseConverter.ConvertName(string.Empty);

            // Assert
            Assert.Equal(string.Empty, actual);
        }
    }
}
