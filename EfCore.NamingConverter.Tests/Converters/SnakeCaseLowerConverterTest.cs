using EfCore.NamingConverter.Converters;

namespace EfCore.NamingConverter.Tests.Converters
{
    public class SnakeCaseLowerConverterTest
    {
        [Fact]
        public void ConvertName_ShouldReturnSnakeCaseLower()
        {
            // Arrange
            var snakeCaseConverter = new SnakeCaseLowerConverter();

            // Act
            var actual = snakeCaseConverter.ConvertName("FullName");

            // Assert
            Assert.Equal("full_name", actual);
        }

        [Fact]
        public void ConvertName_InputEmpty_ShouldReturnEmpty()
        {
            // Arrange
            var snakeCaseConverter = new SnakeCaseLowerConverter();

            // Act
            var actual = snakeCaseConverter.ConvertName(string.Empty);

            // Assert
            Assert.Equal(string.Empty, actual);
        }
    }
}
