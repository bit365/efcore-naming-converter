using EfCore.NamingConverter.Converters;

namespace EfCore.NamingConverter.Tests.Converters
{
    public class SnakeCaseUpperConverterTest
    {
        [Fact]
        public void ConvertName_ShouldReturnSnakeCaseUpper()
        {
            // Arrange
            var snakeCaseConverter = new SnakeCaseUpperConverter();

            // Act
            var actual = snakeCaseConverter.ConvertName("FullName");

            // Assert
            Assert.Equal("FULL_NAME", actual);
        }

        [Fact]
        public void ConvertName_InputEmpty_ShouldReturnEmpty()
        {
            // Arrange
            var snakeCaseConverter = new SnakeCaseUpperConverter();

            // Act
            var actual = snakeCaseConverter.ConvertName(string.Empty);

            // Assert
            Assert.Equal(string.Empty, actual);
        }
    }
}