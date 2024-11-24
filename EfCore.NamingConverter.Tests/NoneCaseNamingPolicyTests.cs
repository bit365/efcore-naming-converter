using Xunit;
using EfCore.NamingConverter;

namespace EfCore.NamingConverter.Tests
{
    public class NoneCaseNamingPolicyTests
    {
        [Fact]
        public void ConvertName_ShouldReturnSameString()
        {
            // Arrange
            var policy = new NoneCaseNamingPolicy();
            var input = "TestName";
            var expected = "TestName";

            // Act
            var result = policy.ConvertName(input);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void ConvertName_ShouldThrowArgumentNullExceptionNullInput()
        {
            // Arrange
            var policy = new NoneCaseNamingPolicy();
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => policy.ConvertName(null));
        }

        [Fact]
        public void ConvertName_ShouldHandleEmptyString()
        {
            // Arrange
            var policy = new NoneCaseNamingPolicy();
            var input = string.Empty;
            var expected = string.Empty;

            // Act
            var result = policy.ConvertName(input);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void ConvertName_ShouldHandleSingleWord()
        {
            // Arrange
            var policy = new NoneCaseNamingPolicy();
            var input = "Word";
            var expected = "Word";

            // Act
            var result = policy.ConvertName(input);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void ConvertName_ShouldHandleMultipleWords()
        {
            // Arrange
            var policy = new NoneCaseNamingPolicy();
            var input = "Multiple Words In String";
            var expected = "Multiple Words In String";

            // Act
            var result = policy.ConvertName(input);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}